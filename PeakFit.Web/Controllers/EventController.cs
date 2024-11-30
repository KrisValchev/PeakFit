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
using static PeakFit.Web.Attributes.MustBeTrainerAttribute;
using static PeakFit.Infrastructure.Constraints.Errors;
using System.Globalization;
using System.Diagnostics.Tracing;
using PeakFit.Web.Attributes;
namespace PeakFit.Web.Controllers
{

    public class EventController(IEventService eventService, UserManager<ApplicationUser> userManager) : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllEventsQueryModel model)
        {
            var _event = await eventService.AllEventsAsync(
                model.Search,
                model.Sorting,
                model.CurrentPage,
                model.EventsPerPage);
            model.TotalEventsCount = _event.TotalEventsCount;
            model.Events = _event.Events;
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            if (await eventService.ExistAsync(id) == false)
            {
                return BadRequest();

            }
            var model = await eventService.DetailsAsync(id);
            return View(model);
        }
        [HttpGet]
        [MustBeTrainer]
        public async Task<IActionResult> Edit(int id)
        {
            //getting the current user
            var currentUser = await userManager.GetUserAsync(User);

            if (await eventService.ExistAsync(id) == false)
            {
				return BadRequest();
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
        [MustBeTrainer]
        public async Task<IActionResult> Edit(int id, EditEventModel model)
        {
            //getting the current user
            var currentUser = await userManager.GetUserAsync(User);

            if (await eventService.ExistAsync(id) == false)
            {
				return BadRequest();
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

			if (User.IsAdmin())
			{
				return RedirectToAction("ManageEvents", "Management", new { area = "Administrator" });
			}

			return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        [MustBeTrainer]
        public async Task<IActionResult> Create()
        {
            var model = new AddEventsModel();
            model.StartDate = DateTime.Now.AddDays(1).ToString(StartDateTimeFormat);
            return View(model);
        }
        [HttpPost]
        [MustBeTrainer]
        public async Task<IActionResult> Create(AddEventsModel model)
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
            //check if the start date is in the future
            if (startDate < DateTime.Today)
            {
                ModelState.AddModelError(nameof(model.StartDate), EventCantStartWithPreviousDateErrorMessage);
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
        [MustBeTrainer]
        public async Task<IActionResult> Delete(int id)
        {
            //getting the current user
            var currentUser = await userManager.GetUserAsync(User);

            if (await eventService.ExistAsync(id) == false)
            {
				return BadRequest();
			}
            var _event = await eventService.DetailsAsync(id);
            if (_event.TrainerId != currentUser.Id && User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            await eventService.DeleteAsync(id);
			if (User.IsAdmin())
			{
				return RedirectToAction("ManageEvents", "Management", new { area = "Administrator" });
			}
			return RedirectToAction(nameof(All));
        }
    }
}
