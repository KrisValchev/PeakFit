﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
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
        public async Task<IActionResult> All([FromQuery] AllTrainingProgramQueryModel model)
        {
			var program = await programService.AllTrainingProgramsAsync(
				model.Search,
				model.Sorting,
				model.CurrentPage,
				model.TrainingProgramPerPage,
				model.Category);
			model.TotalTrainingProgramsCount = program.TotalTrainingProgramsCount;
			model.Categories = await programService.AllCategoriesNamesAsync();
			model.TrainingPrograms=program.TrainingPrograms;

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            if (await programService.ExistAsync(id) == false)
            {
				return BadRequest();
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
				return BadRequest();
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
			if (User.IsAdmin())
			{
				return RedirectToAction("ManageTrainingPrograms", "Management", new { area = "Administrator" });
			}
			return RedirectToAction(nameof(Details), new { id });
        }
        [HttpGet]
        [MustBeTrainer]
        public async Task<IActionResult> Mine([FromQuery] AllTrainingProgramQueryModel model)
        {
            var currentUser = await userManager.GetUserAsync(User);

            var program = await programService.MineTrainingProgramsAsync(
                currentUser
                ,model.CurrentPage
                ,model.TrainingProgramPerPage);
			model.TotalTrainingProgramsCount = program.TotalTrainingProgramsCount;
			model.TrainingPrograms = program.TrainingPrograms;

			return View(model);
        }

        [HttpGet]
        [MustBeTrainer]
        public async Task<IActionResult> Delete (int id)
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
			await programService.DeleteAsync(id);
			if (User.IsAdmin())
			{
				return RedirectToAction("ManageTrainingPrograms", "Management", new { area = "Administrator" });
			}
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
				return BadRequest();
			}

			if (program.UserProgram != null && program.UserProgram.Any(up=>up.ProgramId==id && up.UserId==currentUser.Id))
			{
				return RedirectToAction(nameof(LikedPrograms));
			}
			else
			{
				await programService.AddToUsersProgramsAsync(id, currentUser);

				return RedirectToAction(nameof(All));
			}
		}
		[HttpGet]
        [NotATrainer]
		public async Task<IActionResult> LikedPrograms([FromQuery] AllTrainingProgramQueryModel model)
		{
			var currentUser = await userManager.GetUserAsync(User);
			var likedPrograms = await programService.LikedProgramsAsync(currentUser
				, model.CurrentPage
				, model.TrainingProgramPerPage);
			model.TotalTrainingProgramsCount = likedPrograms.TotalTrainingProgramsCount;
			model.TrainingPrograms = likedPrograms.TrainingPrograms;
			return View(model);
		}

		[HttpPost]
        [NotATrainer]
		public async Task<IActionResult> RemoveFromLikedPrograms(int id)
		{
			if (await programService.ExistAsync(id) == false)
			{
				return BadRequest();
			}

			var currentUser = await userManager.GetUserAsync(User);

			await programService.RemoveFromUsersProgramsAsync(id, currentUser);

			return RedirectToAction(nameof(LikedPrograms));
		}
	}
}
