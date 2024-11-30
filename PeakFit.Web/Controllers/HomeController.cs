using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PeakFit.Infrastructure.Data.Models;
using PeakFit.Web.Models;
using System.Diagnostics;

namespace PeakFit.Web.Controllers
{
	public class HomeController(ILogger<HomeController> _logger) : Controller
	{

		public IActionResult Index()
		{
			return View();
		}
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(int statusCode)
		{
            if (statusCode == 400)
            {
                return View("Error400");
            }
			if (statusCode == 401)
			{
				return View("Error401");
			}
			if (statusCode == 404)
            {
                return View("Error404");
            }

            return View();
        }
	}
}
