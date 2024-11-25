using PeakFit.Core.Models.CommentModels;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Contracts
{
	public interface ICommentService
	{
		Task DeleteAsync(int commentId);
		Task<bool> ExistsAsync(int id);
		Task<CommentsInfoViewModel> CommentInformationByIdAsync(int id);
		Task AddAsync(CommentAddViewModel model, ApplicationUser authorId, int eventId);
		Task<IEnumerable<CommentsInfoViewModel>> AllCommentsAsync();

	}
}
