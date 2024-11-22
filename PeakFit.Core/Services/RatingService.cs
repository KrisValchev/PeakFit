using Microsoft.EntityFrameworkCore;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.RatingModels;
using PeakFit.Infrastructure.Common;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Services
{
	public class RatingService(IRepository repository) : IRatingService
	{
		//DeleteRatingAsync method is used to delete rating and it takes RatingViewModel as parameter
		public async Task DeleteRatingAsync(RatingViewModel rating)
		{
			var actualRating = await repository.All<Rating>()
				.Where(r => r.UserId == rating.UserId && r.TrainingProgramId == rating.TrainingProgramId)
				.FirstOrDefaultAsync();
			if (actualRating != null)
			{
				await repository.DeleteAsync<Rating>(actualRating.Id);
				await repository.SaveChangesAsync();
			}
		}
		//GetProgramRatingStatsAsync method is used to get program rating stats and it takes trainingProgramId as parameter and returns a tuple of double and int
		public async Task<(double averageRating, int totalRatings)> GetProgramRatingStatsAsync(int trainingProgramId)
		{
			var ratings = await repository.AllReadOnly<Rating>()
		.Where(r => r.TrainingProgramId == trainingProgramId)
		.ToListAsync();

			var totalRatings = ratings.Count;
			var averageRating = totalRatings > 0 ? ratings.Average(r => r.Value) : 0;

			return (averageRating, totalRatings);
		}
		//GetRatingAsync method is used to get rating and it takes userId and trainingProgramId as parameters and returns RatingViewModel
		public async Task<RatingViewModel> GetRatingAsync(string userId, int trainingProgramId)
		{
			var rating = await repository.AllReadOnly<Rating>()
				.Where(r => r.UserId == userId && r.TrainingProgramId == trainingProgramId)
				.Select(r => new RatingViewModel
				{
					TrainingProgramId = r.TrainingProgramId,
					UserId = r.UserId,
					Value = r.Value
				})
				.FirstOrDefaultAsync();

			return rating;


		}
		//SaveRatingAsync method is used to save rating and it takes RatingViewModel as parameter
		public async Task SaveRatingAsync(RatingViewModel rating)
		{

			var newRating = new Rating
			{
				TrainingProgramId = rating.TrainingProgramId,
				UserId = rating.UserId,
				Value = rating.Value
			};
			await repository.AddAsync<Rating>(newRating);
			await repository.SaveChangesAsync();
		}
	}
}
