using Microsoft.AspNetCore.Mvc;
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

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
