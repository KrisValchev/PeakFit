using Microsoft.AspNetCore.Mvc;

namespace PeakFit.Web.Areas.Administrator.Components
{
    public class AdminMenuComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
