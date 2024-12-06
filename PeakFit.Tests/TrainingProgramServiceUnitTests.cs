using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.ProgramExerciseModels;
using PeakFit.Core.Models.TrainingProgramModels;
using PeakFit.Core.Services;
using PeakFit.Infrastructure.Common;
using PeakFit.Infrastructure.Data.Models;
using PeakFit.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Tests
{
	[TestFixture]
	public class TrainingProgramServiceUnitTests
	{
		private ApplicationDbContext dbContext;

		private IRepository repository;
		private ITrainingProgramService trainingProgramService;


		private TrainingProgram Program1;
		private TrainingProgram Program2;

		private ApplicationUser User;
		private ApplicationUser User2;
		private ApplicationUser Trainer;
		private ApplicationUser Trainer2;
		private Category Category;

		private Rating Rating1;
		private Rating Rating2;

		private Exercise Exercise1;
		private Exercise Exercise2;

		private ProgramExercise ProgramExercise1;
		private ProgramExercise ProgramExercise2;

		private UserProgram UserProgram1;
		private UserProgram UserProgram2;

		[SetUp]
		public async Task Setup()
		{
			//Arrange
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
				Id = "8360fe51-a38f-4bff-81b1-45bcebdf3d3f",
				UserName = "trainer1@gmail.com",
				NormalizedUserName = "trainer1@gmail.com",
				Email = "trainer1@gmail.com",
				NormalizedEmail = "trainer1@gmail.com",
				FirstName = "Trainer1",
				LastName = "Trainer1",
				PhoneNumber = "0888888888",
				Gender = "Female",
			};
			Trainer2 = new ApplicationUser
			{
				Id = "098ca3d4-3cdc-4139-b146-4b5e61a064bb",
				UserName = "trainer2@gmail.com",
				NormalizedUserName = "trainer2@gmail.com",
				Email = "trainer2@gmail.com",
				NormalizedEmail = "trainer2@gmail.com",
				FirstName = "Trainer2",
				LastName = "Trainer2",
				PhoneNumber = "08888098888",
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
			Program2 = new TrainingProgram
			{
				Id = 2,
				IsDeleted = false,
				UserId = Trainer2.Id,
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
				ProgramId = Program2.Id,
				Reps = 10,
				Sets = 3
			};

			UserProgram1 = new UserProgram
			{
				UserId = User.Id,
				ProgramId = Program1.Id,
			};
			UserProgram2 = new UserProgram
			{
				UserId = User.Id,
				ProgramId = Program2.Id,
			};

			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			  .UseInMemoryDatabase(databaseName: "ApplicationInMemoryDb" + Guid.NewGuid().ToString())
			  .Options;

			dbContext = new ApplicationDbContext(options);
			await dbContext.AddAsync(User);
			await dbContext.AddAsync(Trainer);
			await dbContext.AddAsync(User2);
			await dbContext.AddAsync(Trainer2);

			await dbContext.AddAsync(Category);

			await dbContext.AddAsync(Program1);
			await dbContext.AddAsync(Program2);

			await dbContext.AddAsync(Exercise1);
			await dbContext.AddAsync(Exercise2);

			await dbContext.AddAsync(ProgramExercise1);
			await dbContext.AddAsync(ProgramExercise2);

			await dbContext.AddAsync(Rating1);
			await dbContext.AddAsync(Rating2);

			await dbContext.AddAsync(UserProgram1);
			await dbContext.AddAsync(UserProgram2);

			await dbContext.SaveChangesAsync();

			repository = new Repository(dbContext);
			trainingProgramService = new TrainingProgramService(repository);

		}
		[TearDown]
		public async Task TearDown()
		{
			await dbContext.Database.EnsureDeletedAsync();
			await dbContext.DisposeAsync();
		}
		[Test]
		public async Task DetailsAsync_ShouldReturnCorrectProgram()
		{
			//Act
			var result = await trainingProgramService.DetailsAsync(Program1.Id);
			//Assert
			Assert.AreEqual(Program1.Id, result.Id);
			Assert.AreEqual(Program1.UserId, result.TrainerId);
			Assert.AreEqual(Program1.CategoryId, result.CategoryId);
			Assert.AreEqual(Program1.Ratings.Count, result.Ratings.Count);
			Assert.AreEqual(Program1.Exercises.Count, result.Exercises.Count);
			Assert.AreEqual(Program1.ImageUrl, result.ImageUrl);

		}
		[Test]
		public async Task AllCategoriesNamesAsync_ShouldReturnCorrectCategories()
		{
			//Act
			var result = await trainingProgramService.AllCategoriesNamesAsync();
			//Assert
			Assert.AreEqual(1, result.Count());
			Assert.AreEqual(Category.CategoryName, result.FirstOrDefault());
		}
		[Test]
		public async Task AllCategoriesAsync_ShouldReturnCorrectCategories()
		{
			//Act
			var result = await trainingProgramService.AllCategoriesAsync();
			//Assert
			Assert.AreEqual(1, result.Count());
			Assert.AreEqual(Category.CategoryName, result.FirstOrDefault().CategoryName);
		}
		[Test]
		public async Task AddAsync_ShouldAddProgram()
		{
			//Arrange
			var model = new AddTrainingProgramModel
			{
				CategoryId = Category.Id,
				ImageUrl = "ImageUrl",
				ProgramExercises = new List<ProgramExerciseAddModel>
				{
					new ProgramExerciseAddModel
					{
						ExerciseId = Exercise1.Id,
						Reps = 10,
						Sets = 1
					}
				}
			};
			//Act
			var result = await trainingProgramService.AddAsync(model, Trainer);
			//Assert
			Assert.AreEqual(3, result);
		}
		[Test]
		public async Task ExistAsync_ShouldReturnTrue()
		{
			//Act
			var result = await trainingProgramService.ExistAsync(Program1.Id);
			//Assert
			Assert.IsTrue(result);
		}
		[Test]
		public async Task ExistAsync_ShouldReturnFalse()
		{
			//Act
			var result = await trainingProgramService.ExistAsync(3);
			//Assert
			Assert.IsFalse(result);
		}
		[Test]
		public async Task MineTrainingProgramsAsync_ShouldReturnCorrectPrograms()
		{
			//Act
			var result = await trainingProgramService.MineTrainingProgramsAsync(Trainer);
			//Assert
			Assert.AreEqual(1, result.TrainingPrograms.Count());
			Assert.AreEqual(Program1.Id, result.TrainingPrograms.FirstOrDefault().Id);
			Assert.AreEqual(Program1.UserId, result.TrainingPrograms.FirstOrDefault().TrainerId);
			Assert.AreEqual(Program1.CategoryId, result.TrainingPrograms.FirstOrDefault().CategoryId);
			Assert.AreEqual(Program1.Ratings.Count, result.TrainingPrograms.FirstOrDefault().Ratings.Count);
			Assert.AreEqual(Program1.Exercises.Count, result.TrainingPrograms.FirstOrDefault().ExerciseCount);
			Assert.AreEqual(Program1.ImageUrl, result.TrainingPrograms.FirstOrDefault().ImageUrl);

		}
		[Test]
		public async Task MineTrainingProgramsAsync_ShouldReturnCorrectProgramsCount()
		{
			//Act
			var result = await trainingProgramService.MineTrainingProgramsAsync(Trainer);
			//Assert
			Assert.AreEqual(1, result.TotalTrainingProgramsCount);
		}

		[Test]
		public async Task DeleteAsync_ShouldDeleteProgram()
		{
			//Act
			await trainingProgramService.DeleteAsync(Program1.Id);
			var result = await trainingProgramService.ExistAsync(Program1.Id);
			//Assert
			Assert.IsFalse(result);
		}


		[Test]
		public async Task LikedProgramsAsync_ShouldReturnCorrectPrograms()
		{
			//Act
			var result = await trainingProgramService.LikedProgramsAsync(User, 1, 3);
			//Assert
			Assert.AreEqual(2, result.TotalTrainingProgramsCount);
			Assert.AreEqual(Program1.Id, result.TrainingPrograms.FirstOrDefault().Id);
			Assert.AreEqual(Program1.UserId, result.TrainingPrograms.FirstOrDefault().TrainerId);
			Assert.AreEqual(Program1.CategoryId, result.TrainingPrograms.FirstOrDefault().CategoryId);
			Assert.AreEqual(Program1.Ratings.Count, result.TrainingPrograms.FirstOrDefault().Ratings.Count);
			Assert.AreEqual(Program1.Exercises.Count, result.TrainingPrograms.FirstOrDefault().ExerciseCount);
			Assert.AreEqual(Program1.ImageUrl, result.TrainingPrograms.FirstOrDefault().ImageUrl);
		}
		[Test]
		public async Task EditAsync_ShouldEditProgram()
		{
			//Arrange
			var model = new EditTrainingProgramViewModel
			{
				CategoryId = Category.Id,
				ImageUrl = "ImageUrl",
				ProgramExercises = new List<ProgramExerciseAddModel>
				{
					new ProgramExerciseAddModel
					{
						ExerciseId = Exercise1.Id,
						Reps = 10,
						Sets = 1
					}
				}
			};
			//Act
			await trainingProgramService.EditAsync(Program1.Id, model);
			var result = await dbContext.TrainingPrograms.FirstOrDefaultAsync(p => p.Id == Program1.Id);
			//Assert
			Assert.AreEqual(Program1.Id, result.Id);
			Assert.AreEqual(Program1.UserId, result.UserId);
			Assert.AreEqual(Program1.CategoryId, result.CategoryId);
			Assert.AreEqual(Program1.Ratings.Count, result.Ratings.Count);
			Assert.AreEqual(Program1.Exercises.Count, result.Exercises.Count);
			Assert.AreEqual(Program1.ImageUrl, result.ImageUrl);
		}
		[Test]
		public async Task AllTrainingProgramsAsync_ShouldReturnCorrectPrograms()
		{
			//Act
			var result = await trainingProgramService.AllTrainingProgramsAsync(null, 0, 1, 1, null);
			//Assert
			Assert.AreEqual(2, result.TotalTrainingProgramsCount);
			Assert.AreEqual(Program1.Id, result.TrainingPrograms.FirstOrDefault().Id);
			Assert.AreEqual(Program1.UserId, result.TrainingPrograms.FirstOrDefault().TrainerId);
			Assert.AreEqual(Program1.CategoryId, result.TrainingPrograms.FirstOrDefault().CategoryId);
			Assert.AreEqual(Program1.Ratings.Count, result.TrainingPrograms.FirstOrDefault().Ratings.Count);
			Assert.AreEqual(Program1.Exercises.Count, result.TrainingPrograms.FirstOrDefault().ExerciseCount);
			Assert.AreEqual(Program1.ImageUrl, result.TrainingPrograms.FirstOrDefault().ImageUrl);
		}
		[Test]
		public async Task AllTrainingProgramsAsync_ShouldReturnCorrectProgramsCount()
		{
			//Act
			var result = await trainingProgramService.AllTrainingProgramsAsync(null, 0, 1, 1, null);
			//Assert
			Assert.AreEqual(2, result.TotalTrainingProgramsCount);
		}
		[Test]
		public async Task AllTrainingProgramsAsync_ShouldReturnCorrectProgramsPerPage()
		{
			//Act
			var result = await trainingProgramService.AllTrainingProgramsAsync(null, 0, 1, 1, null);
			//Assert
			Assert.AreEqual(1, result.TrainingPrograms.Count());
		}
		

	}
}
