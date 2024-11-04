using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.EventModels;
using PeakFit.Infrastructure.Common;
using static PeakFit.Core.Models.EventModels.AllEventsInfoModel;
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
    }
}
