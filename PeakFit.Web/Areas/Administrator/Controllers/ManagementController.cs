using Microsoft.AspNetCore.Mvc;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.ApplicationUserModels;
using PeakFit.Core.Models.EventModels;
using PeakFit.Core.Models.TrainingProgramModels;
using PeakFit.Core.Services;

namespace PeakFit.Web.Areas.Administrator.Controllers
{
	public class ManagementController(IEventService eventService,ITrainingProgramService programService,ICommentService commentService,IApplicationUserService applicationUserService) : AdminController
	{
		[HttpGet]
		public async Task<IActionResult> ManageUsers([FromQuery] AllUsersQueryModel model)
			{
			var user = await applicationUserService.AllUsersAsync(
				model.Id,
				model.FirstName,
				model.LastName,
				model.Sorting,
				model.CurrentPage,
				model.UsersPerPage);

			model.TotalUsersCount = user.TotalUsersCount;

			model.Users = user.Users;

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> ManageEvents([FromQuery] AllEventsQueryModel model)
		{
			var _event = await eventService.AllEventsAsync(
				model.Search,
				model.Sorting,
				model.CurrentPage,
				model.EventsPerPage);

			model.TotalEventsCount = _event.TotalEventsCount;

			model.Events = _event.Events;

			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> ManageTrainingPrograms([FromQuery] AllTrainingProgramQueryModel model)
		{
			var program = await programService.AllTrainingProgramsAsync(
				model.Search,
				model.Sorting,
				model.CurrentPage,
				model.TrainingProgramPerPage,
				model.Category);
			model.TotalTrainingProgramsCount = program.TotalTrainingProgramsCount;
			model.Categories = await programService.AllCategoriesNamesAsync();
			model.TrainingPrograms = program.TrainingPrograms;

			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> ManageComments()
		{
			var model = await commentService.AllCommentsAsync();
			return View(model);
		}
	}
}
