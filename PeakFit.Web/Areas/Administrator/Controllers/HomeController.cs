using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeakFit.Core.Contracts;
using static PeakFit.Core.Constants.RoleConstants;

namespace PeakFit.Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = AdminRole)]
    public class HomeController(IAdminService adminService) : AdminController
	{
		public async Task<IActionResult> AdminPanel()
		{
			var model = await adminService.PanelInformationAsync();
			return View(model);
		}
	}
}
