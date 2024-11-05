using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.EventModels;
using PeakFit.Infrastructure.Common;
using  PeakFit.Core.Models.EventModels;
namespace PeakFit.Web.Controllers
{
    [Authorize]
    public class EventController(IEventService eventService) : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All(IEnumerable<AllEventsInfoModel> model)
        {
            model = await eventService.AllEventsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if(await eventService.ExistAsync(id)==false)
            {
                //should return BadRequest
                return RedirectToAction(nameof(All));
            }
            var model = await eventService.DetailsAsync(id);
            return View(model);
        }
    }
}
