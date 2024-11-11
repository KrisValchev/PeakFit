using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PeakFit.Core.Contracts;
using PeakFit.Web.Extensions;
using static PeakFit.Core.Contracts.ITrainerService;

namespace PeakFit.Web.Attributes
{
    public class NotATrainerAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            ITrainerService? trainerService = context.HttpContext.RequestServices.GetService<ITrainerService>();

            if (trainerService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (trainerService!=null && trainerService.IsInTrainerRoleAsync(context.HttpContext.User.Id()).Result)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
