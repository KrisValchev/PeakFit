using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.ApplicationUserModels;
using PeakFit.Infrastructure.Data.Models;
using PeakFit.Web.Data.Migrations;
using PeakFit.Web.Extensions;
using static PeakFit.Infrastructure.Constraints.ApplicationUserDataConstraints;
using static PeakFit.Core.Constants.MessageConstants;

namespace PeakFit.Web.Controllers
{
	public class UserController(IApplicationUserService applicationUserService, UserManager<ApplicationUser> userManager) : Controller
	{
		[HttpGet]
		public async Task<IActionResult> All([FromQuery] AllUsersQueryModel model)
		{
			var users = await applicationUserService.AllUsersAsync(
				model.Id,
				model.FirstName,
				model.LastName,
				model.Sorting,
				model.CurrentPage,
				model.UsersPerPage);

			model.TotalUsersCount = users.TotalUsersCount;

			model.Users = users.Users;

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(string id)
		{
			var userToDelete = await applicationUserService.UserDetailsAsync(id);

			if (await applicationUserService.ExistsAsync(id) == false || User.Id() == userToDelete.Id)
			{
				return BadRequest();
			}

			if (User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			var model = new UsersDetailsServiceModel()
			{
				Id = userToDelete.Id,
				UserName = userToDelete.UserName,
				Email = userToDelete.Email,
				FirstName = userToDelete.FirstName,
				LastName = userToDelete.LastName
			};
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(UsersDetailsServiceModel model)
		{
			if (await applicationUserService.ExistsAsync(model.Id) == false || User.Id() == model.Id)
			{
				return BadRequest();
			}

			if (User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			await applicationUserService.DeleteAsync(model.Id);

			return RedirectToAction("ManageUsers", "Management", new { area = "Administrator" });
		}

		[HttpGet]
		public async Task<IActionResult> PromoteToAdmin(string id)
		{
			var currentUser = await userManager.GetUserAsync(User);
			if (await applicationUserService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if (User.IsAdmin() == false || id == currentUser.Id)
			{
				return Unauthorized();
			}
			var userToPromote = await applicationUserService.UserDetailsAsync(id);

			var model = new UsersPromoteServiceModel()
			{
				Id = userToPromote.Id,
				PhoneNumber = userToPromote.PhoneNumber
			};
			return View( model);
		}

		[HttpPost]
		public async Task<IActionResult> PromoteToAdmin(UsersPromoteServiceModel model)
		{
			var currentUser = await userManager.GetUserAsync(User);

			if (await applicationUserService.ExistsAsync(model.Id) == false)
			{
				return BadRequest();
			}

			if (User.IsAdmin() == false || model.Id == currentUser.Id)
			{
				return Unauthorized();
			}
			
			if (await applicationUserService.PhoneNumberExistsAsync(model.PhoneNumber))
			{
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExists);
            }
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await applicationUserService.PromoteUserAsync(model.Id, model.PhoneNumber);
			return RedirectToAction("ManageUsers", "Management", new { area = "Administrator" });
		}

		[HttpGet]
		public async Task<IActionResult> Demote(string id)
		{
			var currentUser = await userManager.GetUserAsync(User);
			if (await applicationUserService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if (User.IsAdmin() == false || id == currentUser.Id)
			{
				return Unauthorized();
			}

			var userToDemote = await applicationUserService.UserDetailsAsync(id);

			var model = new UsersDetailsServiceModel()
			{
				Id = userToDemote.Id,
				UserName = userToDemote.UserName,
				Email = userToDemote.Email,
				FirstName = userToDemote.FirstName,
				LastName = userToDemote.LastName
			};
			return View(model);
		}


		[HttpPost]
		public async Task<IActionResult> Demote(UsersDetailsServiceModel model)
		{
			var currentUser = await userManager.GetUserAsync(User);
			if (await applicationUserService.ExistsAsync(model.Id) == false)
			{
				return BadRequest();
			}

			if (User.IsAdmin() == false || model.Id == currentUser.Id)
			{
				return Unauthorized();
			}

			await applicationUserService.DemoteUserAsync(model.Id);

			return RedirectToAction("ManageUsers", "Management", new { area = "Administrator" });
		}
	}
}
