using Microsoft.EntityFrameworkCore;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.CommentModels;
using PeakFit.Infrastructure.Common;
using PeakFit.Infrastructure.Constraints;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PeakFit.Infrastructure.Constraints.CommentDataConstraints;

namespace PeakFit.Core.Services
{
	public class CommentService(IRepository repository) : ICommentService
	{
		public async Task AddAsync(CommentAddViewModel model, ApplicationUser authorId, int eventId)
		{
			Comment newComment = new Comment
			{
				Title = model.Title,
				Description = model.Description,
				UserId = authorId.Id,
				PostedOn = DateTime.Now,
				EventId = eventId
			};

			await repository.AddAsync(newComment);
			await repository.SaveChangesAsync();
		}

		public async Task<IEnumerable<CommentsInfoViewModel>> AllCommentsAsync()
		{
			return await repository.AllReadOnly<Comment>()
				.Where(c => c.IsDeleted == false)
			   .OrderByDescending(c => c.PostedOn)
			   .Select(c => new CommentsInfoViewModel()
			   {
				   Id = c.Id,
				   Title = c.Title,
				   Description = c.Description,
				   AuthorFirstName = c.User.FirstName,
				   AuthorLastName = c.User.LastName,
				   AuthorProfilePicture = c.User.ProfilePicture,
				   PostedOn = c.PostedOn.ToString(PostedOnDateTimeFormat),
				   EventId = c.EventId,
				   EventName = c.Event.Title,
				   AuthorId = c.UserId
			   })
			   .ToListAsync();

		}


		public async Task<CommentsInfoViewModel> CommentInformationByIdAsync(int id)
		{
			return await repository.AllReadOnly<Comment>()
				.Where(c => c.Id == id)
				.Select(c => new CommentsInfoViewModel()
				{
					Id = c.Id,
					Title = c.Title,
					Description = c.Description,
					AuthorFirstName = c.User.FirstName,
					AuthorLastName = c.User.LastName,
					AuthorProfilePicture = c.User.ProfilePicture,
					PostedOn = c.PostedOn.ToString(PostedOnDateTimeFormat),
					EventId = c.EventId,
					EventName = c.Event.Title,
					AuthorId = c.UserId
				})
				.FirstAsync();
		}

		public async Task DeleteAsync(int commentId)
		{
			var comment = await repository.All<Comment>()
				.Where(c => c.Id == commentId && c.IsDeleted == false)
				.FirstOrDefaultAsync();
			comment.IsDeleted = true;
			await repository.SaveChangesAsync();
		}

		public async Task<bool> ExistsAsync(int id)
		{
			return await repository.AllReadOnly<Comment>()
			   .AnyAsync(c => c.Id == id && c.IsDeleted==false);

		}
	}
}
