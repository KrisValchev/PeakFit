using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeakFit.Core.Contracts;
using  PeakFit.Core.Models.TrainingProgramModels;
using PeakFit.Core.Services;
using PeakFit.Web.Attributes;
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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            if (await programService.ExistAsync(id) == false)
            {
                //should return BadRequest
                return RedirectToAction(nameof(All));
            }
            var model = await programService.DetailsAsync(id);
            return View(model);
        }
        [HttpGet]
        [MustBeTrainer]
        public async Task<IActionResult> Add()
        {
            var newProgram = new AddTrainingProgramModel()
            {
                Categories = await programService.AllCategoriesAsync()
            };

            return View(newProgram);
        }
    }
}
