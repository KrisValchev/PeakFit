using Microsoft.AspNetCore.Mvc;
using PeakFit.Core.Models.TrainerModels;
using PeakFit.Core.Services;
using PeakFit.Web.Extensions;
using static PeakFit.Core.Models.TrainerModels.BecomeTrainerModel;
using PeakFit.Core.Contracts;
using static PeakFit.Core.Constants.MessageConstants;
using static PeakFit.Core.Constants.RoleConstants;
using Microsoft.AspNetCore.Identity;
using PeakFit.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using PeakFit.Web.Attributes;

namespace PeakFit.Web.Controllers
{

    public class TrainerController(ITrainerService trainerService) : Controller
    {
        [HttpGet]
        [NotATrainer]
        public IActionResult Become()
        {
            var model = new BecomeTrainerModel();

            return View(model);
        }
        [HttpPost]
        [NotATrainer]
        public async Task<IActionResult> Become(BecomeTrainerModel model)
        {
            if (await trainerService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExists);
            }


            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await trainerService.RemoveLikedPrograms(User.Id());
            await trainerService.AddPhoneNumberAsync(User.Id(), model);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


    }
}
