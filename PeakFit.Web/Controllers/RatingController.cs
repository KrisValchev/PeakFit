using Microsoft.AspNetCore.Mvc;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.RatingModels;
using PeakFit.Infrastructure.Data.Models;
using PeakFit.Web.Data;
using PeakFit.Web.Extensions;
using static PeakFit.Core.Contracts.IRatingService;
namespace PeakFit.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RatingController(IRatingService ratingService) : Controller
	{
		[HttpPost]
		public async Task<IActionResult> SubmitRating([FromBody] RatingViewModel rating)
		{
			if (rating == null)
			{
				return BadRequest("Rating object is null.");
			}

			if (rating.Value < 1 || rating.Value > 5)
			{
				return BadRequest("Invalid rating value: " + rating.Value);
			}

			try
			{
				rating.UserId = User.Id();
				// Check if the user already has a rating for this program
				var existingRating = await ratingService.GetRatingAsync(rating.UserId, rating.TrainingProgramId);
				if (existingRating != null)
				{
					// Remove the existing rating
					await ratingService.DeleteRatingAsync(existingRating);
				}
				// Save rating to the database (use your DbContext or repository)
				await ratingService.SaveRatingAsync(rating);
				// Calculate updated average rating and total ratings
				var (averageRating, totalRatings) = await ratingService.GetProgramRatingStatsAsync(rating.TrainingProgramId);
				return Ok(new
				{
					message = "Rating submitted successfully!",
					averageRating,
					totalRatings,
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Internal server error: " + ex.Message);
			}
		}

		[HttpGet("{trainingProgramId}")]
		public async Task<IActionResult> GetRating(int trainingProgramId)
		{
			try
			{
				var userId = User.Id(); // Retrieve the logged-in user's ID
				var rating = await ratingService.GetRatingAsync(userId, trainingProgramId);

				if (rating == null)
				{
					return Ok(new { ratingValue = 0 }); // No rating found, return 0
				}

				return Ok(new { ratingValue = rating.Value }); // Return the user's rating
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Internal server error: " + ex.Message);
			}
		}
	}
}
