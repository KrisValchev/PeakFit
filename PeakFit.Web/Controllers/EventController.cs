using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.EventModels;
using PeakFit.Infrastructure.Common;
using PeakFit.Core.Models.EventModels;
using Microsoft.AspNetCore.Identity;
using PeakFit.Infrastructure.Data.Models;
using static PeakFit.Web.Extensions.ClaimsPrincipalExtensions;
using static PeakFit.Core.Constants.RoleConstants;
using static PeakFit.Infrastructure.Constraints.EventDataConstraints;
using System.Globalization;
using System.Diagnostics.Tracing;
namespace PeakFit.Web.Controllers
{

    public class EventController(IEventService eventService, UserManager<ApplicationUser> userManager) : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All(IEnumerable<AllEventsInfoModel> model)
        {
            model = await eventService.AllEventsAsync();
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            if (await eventService.ExistAsync(id) == false)
            {
                //should return BadRequest
                return RedirectToAction(nameof(All));
            }
            var model = await eventService.DetailsAsync(id);
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = $"{AdminRole},{TrainerRole}")]
        public async Task<IActionResult> Edit(int id)
        {
            //getting the current user
            var currentUser = await userManager.GetUserAsync(User);

            if (await eventService.ExistAsync(id) == false)
            {
                //should return BadRequest
                return RedirectToAction(nameof(All));
            }
            var _event = await eventService.DetailsAsync(id);
            if (_event.TrainerId != currentUser.Id && User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            var model = await eventService.GetEventFromEditEventViewModelByIdAsync(id);
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = $"{AdminRole},{TrainerRole}")]
        public async Task<IActionResult> Edit(int id, EditEventModel model)
        {
            //getting the current user
            var currentUser = await userManager.GetUserAsync(User);

            if (await eventService.ExistAsync(id) == false)
            {
                //should return BadRequest
                return RedirectToAction(nameof(All));
            }
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            DateTime startDate;
            if (DateTime.TryParseExact(model.StartDate.Normalize(), StartDateTimeFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out startDate) == false)
            {
                ModelState.AddModelError(nameof(model.StartDate), "Invalid date format");
                return View(model);
            }


            DateTime startHour;
            if (DateTime.TryParseExact(model.StartHour.Normalize(), StartHourTimeFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out startHour) == false)
            {
                ModelState.AddModelError(nameof(model.StartHour), "Invalid time format");
                return View(model);
            }
            await eventService.EditAsync(id, model);

            //Admin return view implement!

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        [Authorize(Roles = $"{AdminRole},{TrainerRole}")]
        public async Task<IActionResult> Create()
        {
            var model = new AddEventModel();
            model.StartDate = DateTime.Now.ToString(StartDateTimeFormat);
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = $"{AdminRole},{TrainerRole}")]
        public async Task<IActionResult> Create(AddEventModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model); 
            }

            DateTime startDate;
            if (DateTime.TryParseExact(model.StartDate.Normalize(), StartDateTimeFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out startDate) == false)
            {
                ModelState.AddModelError(nameof(model.StartDate), "Invalid date format");
                return View(model);
            }


            DateTime startHour;
            if (DateTime.TryParseExact(model.StartHour.Normalize(), StartHourTimeFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out startHour) == false)
            {
                ModelState.AddModelError(nameof(model.StartHour), "Invalid time format");
                return View(model);
            }
            var trainerId=await userManager.GetUserAsync(User);
            int newEvent=await eventService.CreateAsync(model, trainerId);
            return RedirectToAction(nameof(Details), new {id=newEvent});   
        }
        [HttpGet]
        [Authorize(Roles = $"{AdminRole},{TrainerRole}")]
        public async Task<IActionResult> Delete(int id)
        {
            //getting the current user
            var currentUser = await userManager.GetUserAsync(User);

            if (await eventService.ExistAsync(id) == false)
            {
                //should return BadRequest
                return RedirectToAction(nameof(All));
            }
            var _event = await eventService.DetailsAsync(id);
            if (_event.TrainerId != currentUser.Id && User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            await eventService.DeleteAsync(id);
            return RedirectToAction(nameof(All));
        }
    }
}
