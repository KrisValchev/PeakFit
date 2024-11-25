using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeakFit.Core.Contracts;
using  PeakFit.Core.Models.TrainingProgramModels;
using PeakFit.Core.Services;
using PeakFit.Infrastructure.Data.Models;
using PeakFit.Web.Attributes;
using PeakFit.Web.Extensions;
namespace PeakFit.Web.Controllers
{
    public class TrainingProgramController(ITrainingProgramService programService, UserManager<ApplicationUser> userManager) : Controller
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
                Categories = await programService.AllCategoriesAsync(),
            };

            return View(newProgram);
        }

        [HttpPost]
        [MustBeTrainer]
        public async Task<IActionResult> Add(AddTrainingProgramModel model)
        {

            var trainerId = await userManager.GetUserAsync(User);
            if(ModelState.IsValid == false)
            {
                return View(model);
            }

            int programId = await programService.AddAsync(model, trainerId);

            return RedirectToAction(nameof(Mine), new { id = programId });
        }

        [HttpGet]
        [MustBeTrainer]
        public async Task<IActionResult> Edit(int id)
        {
            //getting the current user
            var currentUser = await userManager.GetUserAsync(User);

            if (await programService.ExistAsync(id) == false)
            {
                //should return BadRequest
                return RedirectToAction(nameof(All));
            }
            var program = await programService.DetailsAsync(id);
            if (program.TrainerId != currentUser.Id && User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            var model = await programService.GetTrainingProgramFromEditTrainingProgramViewModelByIdAsync(id);
            return View(model);
        }
        [HttpPost]
        [MustBeTrainer]
        public async Task<IActionResult> Edit(int id,EditTrainingProgramViewModel model)
        {
            var currentUser = await userManager.GetUserAsync(User);

            if (await programService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var program = await programService.DetailsAsync(id);

            if (program.TrainerId != currentUser.Id && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await programService.EditAsync(id, model);

            //admin panel redirect management
            return RedirectToAction(nameof(Details), new { id });
        }
        [HttpGet]
        [MustBeTrainer]
        public async Task<IActionResult> Mine(IEnumerable<AllTrainingProgramsInfoModel> model)
        {
            var currentUser = await userManager.GetUserAsync(User);

            model = await programService.MineTrainingProgramsAsync(currentUser);

            return View(model);
        }

        [HttpGet]
        [MustBeTrainer]
        public async Task<IActionResult> Delete (int id)
		{
			var currentUser = await userManager.GetUserAsync(User);

			if (await programService.ExistAsync(id) == false)
			{
				//should return BadRequest
				return RedirectToAction(nameof(All));
			}
			var program = await programService.DetailsAsync(id);
			if (program.TrainerId != currentUser.Id && User.IsAdmin() == false)
			{
				return Unauthorized();
			}
			await programService.DeleteAsync(id);
			return RedirectToAction(nameof(Mine));
		}

		[HttpPost]
        [NotATrainer]
		public async Task<IActionResult> AddToLikedPrograms(int id)
		{
			var currentUser = await userManager.GetUserAsync(User);

			var program = await programService.DetailsAsync(id);

			if (await programService.ExistAsync(id) == false)
			{
				//should return BadRequest
				return BadRequest();
			}

			if (program.UserProgram != null && program.UserProgram.ProgramId == id && program.UserProgram.UserId == currentUser.Id)
			{
                //To redirect to LikedPrograms
				return RedirectToAction(nameof(All));
			}
			else
			{
				await programService.AddToUsersProgramsAsync(id, currentUser);

				return RedirectToAction(nameof(All));
			}
		}
		[HttpGet]
        [NotATrainer]
		public async Task<IActionResult> LikedPrograms()
		{
			var currentUser = await userManager.GetUserAsync(User);
			var likedPrograms = await programService.LikedProgramsAsync(currentUser);

			return View(likedPrograms);
		}

		[HttpPost]
        [NotATrainer]
		public async Task<IActionResult> RemoveFromLikedPrograms(int id)
		{
			if (await programService.ExistAsync(id) == false)
			{
                //Should return custom BadRequest
				return BadRequest();
			}

			var currentUser = await userManager.GetUserAsync(User);

			await programService.RemoveFromUsersProgramsAsync(id, currentUser);

			return RedirectToAction(nameof(LikedPrograms));
		}
	}
}
