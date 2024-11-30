using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static PeakFit.Core.Constants.RoleConstants;

namespace PeakFit.Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = AdminRole)]
    public class AdminController : Controller
    {
    
    }
}
