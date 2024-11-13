using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PeakFit.Core.Contracts;
using PeakFit.Web.Controllers;
using PeakFit.Web.Extensions;
using System.Threading.Tasks.Dataflow;
using static PeakFit.Core.Contracts.ITrainerService;
using static PeakFit.Web.Controllers.TrainerController;


namespace PeakFit.Web.Attributes
{
    public class MustBeTrainerAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            ITrainerService? trainerService = context.HttpContext.RequestServices.GetService<ITrainerService>();

            if (trainerService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (trainerService != null
                && trainerService.IsInTrainerRoleAsync(context.HttpContext.User.Id()).Result == false)
            {
                context.Result = new RedirectToActionResult(nameof(TrainerController.Become), "Trainer", null);
            }
        }
    }
}
