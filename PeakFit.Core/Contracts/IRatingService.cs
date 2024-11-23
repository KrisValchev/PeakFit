using PeakFit.Core.Models.RatingModels;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Contracts
{
	public interface IRatingService
	{
		 Task SaveRatingAsync(RatingViewModel rating);
		 Task<RatingViewModel> GetRatingAsync(string userId,int trainingProgramId);
		Task DeleteRatingAsync(RatingViewModel rating);

		Task<(double averageRating, int totalRatings)> GetProgramRatingStatsAsync(int trainingProgramId);
	}
}
