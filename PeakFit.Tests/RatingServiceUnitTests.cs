using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.RatingModels;
using PeakFit.Core.Services;
using PeakFit.Infrastructure.Common;
using PeakFit.Infrastructure.Data.Models;
using PeakFit.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PeakFit.Tests
{
	[TestFixture]
	public class RatingServiceUnitTests
	{
		private ApplicationDbContext dbContext;


		private IRepository repository;
		private IRatingService ratingService;

		private ApplicationUser User;
		private ApplicationUser User2;
		private ApplicationUser Trainer;
		private TrainingProgram Program1;

		private Category Category;

		private Rating Rating1;
		private Rating Rating2;

		private Exercise Exercise1;
		private Exercise Exercise2;

		private ProgramExercise ProgramExercise1;
		private ProgramExercise ProgramExercise2;

		[SetUp]
		public async Task Setup()
		{
			User = new ApplicationUser
			{
				Id = Guid.NewGuid().ToString(),
				UserName = "user1@gmail.com",
				NormalizedUserName = "user1@gmail.com",
				Email = "user1@gmail.com",
				NormalizedEmail = "user1@gmail.com",
				FirstName = "User1",
				LastName = "User1",
				Gender = "Male",
			};
			User2 = new ApplicationUser
			{
				Id = Guid.NewGuid().ToString(),
				UserName = "user2@gmail.com",
				NormalizedUserName = "user2@gmail.com",
				Email = "user2@gmail.com",
				NormalizedEmail = "user2@gmail.com",
				FirstName = "User2",
				LastName = "User2",
				Gender = "Male",
			};
			Trainer = new ApplicationUser
			{
				Id = Guid.NewGuid().ToString(),
				UserName = "trainer1@gmail.com",
				NormalizedUserName = "trainer1@gmail.com",
				Email = "trainer1@gmail.com",
				NormalizedEmail = "trainer1@gmail.com",
				FirstName = "Trainer1",
				LastName = "Trainer1",
				PhoneNumber = "0888888888",
				Gender = "Female",
			};

			Category = new Category
			{
				Id = 1,
				CategoryName = "Category",
			};

			Program1 = new TrainingProgram
			{
				Id = 1,
				IsDeleted = false,
				UserId = Trainer.Id,
				CategoryId = Category.Id,
			};

			Rating1 = new Rating
			{
				Id = 1,
				Value = 5,
				UserId = User.Id,
				TrainingProgramId = Program1.Id,
			};
			Rating2 = new Rating
			{
				Id = 2,
				Value = 4,
				UserId = User2.Id,
				TrainingProgramId = Program1.Id,
			};

			Exercise1 = new Exercise
			{
				Id = 1,
				ExerciseName = "Exercise1",
				CategoryId = Category.Id,
			};

			Exercise2 = new Exercise
			{
				Id = 2,
				ExerciseName = "Exercise2",
				CategoryId = Category.Id,
			};
			ProgramExercise1 = new ProgramExercise
			{
				Id = 1,
				ExerciseId = Exercise1.Id,
				ProgramId = Program1.Id,
				Reps = 10,
				Sets = 1
			};
			ProgramExercise2 = new ProgramExercise
			{
				Id = 2,
				ExerciseId = Exercise2.Id,
				ProgramId = Program1.Id,
				Reps = 10,
				Sets = 3
			};


			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			  .UseInMemoryDatabase(databaseName: "ApplicationInMemoryDb" + Guid.NewGuid().ToString())
			  .Options;

			dbContext = new ApplicationDbContext(options);
			await dbContext.AddAsync(User);
			await dbContext.AddAsync(Trainer);
			await dbContext.AddAsync(User2);


			await dbContext.AddAsync(Category);

			await dbContext.AddAsync(Program1);

			await dbContext.AddAsync(Exercise1);
			await dbContext.AddAsync(Exercise2);

			await dbContext.AddAsync(ProgramExercise1);
			await dbContext.AddAsync(ProgramExercise2);

			await dbContext.AddAsync(Rating1);
			await dbContext.AddAsync(Rating2);

			await dbContext.SaveChangesAsync();
			repository = new Repository(dbContext);

			ratingService = new RatingService(repository);
		}
		[TearDown]
		public async Task TearDown()
		{
			await dbContext.Database.EnsureDeletedAsync();
			await dbContext.DisposeAsync();
		}

		[Test]
		public async Task AddRatingAsync_ShouldAddRating()
		{
			var rating = new RatingViewModel
			{
				Value = 3,
				UserId = User.Id,
				TrainingProgramId = Program1.Id,
			};
			await ratingService.SaveRatingAsync(rating);
			var ratingFromDb = await dbContext.Ratings.LastOrDefaultAsync();
			Assert.IsNotNull(ratingFromDb);
			Assert.AreEqual(rating.Value, ratingFromDb.Value);
			Assert.AreEqual(rating.UserId, ratingFromDb.UserId);
			Assert.AreEqual(rating.TrainingProgramId, ratingFromDb.TrainingProgramId);
		}
		[Test]
		public async Task DeleteRatingAsync_ShouldDeleteRating()
		{
			var rating = new RatingViewModel
			{
				Value = Rating2.Value,
				UserId = Rating2.UserId,
				TrainingProgramId = Rating2.TrainingProgramId,
			};
			await ratingService.DeleteRatingAsync(rating);
			var ratingFromDb = await dbContext.Ratings.ToListAsync();
			Assert.AreEqual(1,ratingFromDb.Count);
		}

		[Test]
		public async Task GetRatingAsync_ShouldReturnRating()
		{
			var rating = await ratingService.GetRatingAsync(Rating1.UserId, Rating1.TrainingProgramId);
			Assert.IsNotNull(rating);
			Assert.AreEqual(Rating1.Value, rating.Value);
			Assert.AreEqual(Rating1.UserId, rating.UserId);
			Assert.AreEqual(Rating1.TrainingProgramId, rating.TrainingProgramId);
		}
		[Test]
		public async Task GetRatingAsync_ShouldReturnNull()
		{
			var rating = await ratingService.GetRatingAsync(Trainer.Id, Program1.Id);
			Assert.IsNull(rating);
		}
		[Test]
		public async Task GetProgramRatingStatsAsync_ShouldReturnStats()
		{
			var stats = await ratingService.GetProgramRatingStatsAsync(Program1.Id);
			Assert.AreEqual(4.5, stats.averageRating);
			Assert.AreEqual(2, stats.totalRatings);
		}
		
	}
}
