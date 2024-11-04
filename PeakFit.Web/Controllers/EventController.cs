using Microsoft.AspNetCore.Mvc;
using PeakFit.Infrastructure.Common;

namespace PeakFit.Web.Controllers
{
    public class EventController(IRepository repository) : Controller
    {
        public Task<IActionResult> All()
        {

            return View();
        }
    }
}
