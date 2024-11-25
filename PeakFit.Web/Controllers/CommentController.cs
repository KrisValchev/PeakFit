using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.CommentModels;
using PeakFit.Core.Services;
using PeakFit.Infrastructure.Data.Models;
using PeakFit.Web.Extensions;

namespace PeakFit.Web.Controllers
{
    public class CommentController(ICommentService commentService,IEventService eventService,UserManager<ApplicationUser> userManager) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> AddComment(int id)
        {

            if (await eventService.ExistAsync(id) == false)
            {
                //custom error page
                return BadRequest();
            }

            var model = new CommentAddViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentAddViewModel model, int id)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var _event = await eventService.DetailsAsync(id);
            if (await eventService.ExistAsync(id) == false)
            {
                //custom error page
                return BadRequest();
            }

            await commentService.AddAsync(model, currentUser, id);
            return RedirectToAction("Details", "Event", new { id});
        }

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var currentUser = await userManager.GetUserAsync(User);

			if (await eventService.ExistAsync(id) == false)
			{
				return BadRequest();
			}

			var comment = await commentService.CommentInformationByIdAsync(id);

			if (currentUser.Id != comment.AuthorId && User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			var model = new CommentsInfoViewModel()
			{
				Id = id,
				Title = comment.Title,
				Description = comment.Description,
				AuthorFirstName = comment.AuthorFirstName,
				AuthorLastName = comment.AuthorLastName,
				AuthorProfilePicture = comment.AuthorProfilePicture,
				PostedOn = comment.PostedOn,
				EventId = comment.EventId,
				EventName = comment.EventName,
				AuthorId = comment.AuthorId
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(CommentsInfoViewModel model)
		{
			var currentUser = await userManager.GetUserAsync(User);

			if (await commentService.ExistsAsync(model.Id) == false)
			{
				return BadRequest();
			}

			var comment = await commentService.CommentInformationByIdAsync(model.Id);

			if (currentUser.Id != comment.AuthorId && User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			var eventToRedirect = await eventService.DetailsAsync(comment.EventId);

			await commentService.DeleteAsync(model.Id);
			//admin panel redirect management
			//if (User.IsAdmin())
			//{
			//	return RedirectToAction("ManageComments", "Management", new { area = "Administrator" });
			//}
			return RedirectToAction("Details", "Event", new { eventToRedirect.Id });
		}
	}
}
