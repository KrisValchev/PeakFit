using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeakFit.Core.Contracts;
using  PeakFit.Core.Models.TrainingProgramModels;
namespace PeakFit.Web.Controllers
{
    public class TrainingProgramController(ITrainingProgramService programService) : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All(IEnumerable<AllTrainingProgramsInfoModel> model)
        {
            model= await programService.AllTrainingProgramsAsync();
            return View(model);
        }


    }
}
