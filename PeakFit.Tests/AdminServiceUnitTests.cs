using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Moq;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.AdminModels;
using PeakFit.Core.Services;
using PeakFit.Infrastructure.Common;
using PeakFit.Infrastructure.Data.Models;
using PeakFit.Web.Data;
using static PeakFit.Core.Constants.RoleConstants;
using static PeakFit.Infrastructure.Constraints.EventDataConstraints;

namespace PeakFit.Tests
{
	[TestFixture]
	public class AdminServiceUnitTests
	{
		private ApplicationDbContext dbContext;

		private UserManager<ApplicationUser> userManager;
		private RoleManager<IdentityRole> roleManager;
		private IRepository repository;
		private IAdminService adminService;

		private Event Event1;

		private TrainingProgram Program1;

		private ApplicationUser User;
		private ApplicationUser Trainer;

		private Comment Comment1;

		private Category Category;

		private Rating Rating1;

		private Exercise Exercise1;

		private ProgramExercise ProgramExercise1;


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
			Event1 = new Event
			{
				Id = 1,
				Title = "Event1",
				Description = "Description",
				StartDate = DateTime.Parse("17-12-2024"),
				StartHour = DateTime.Parse("10:00"),
				IsDeleted = false,
				UserId = Trainer.Id,
				ImageUrl = "https://raceid.com/organizer/wp-content/uploads/2022/08/cost-marathon-featured-image-blog-10.png"
			};

			Comment1 = new Comment
			{
				Id = 1,
				Title = "Comment1",
				Description = "Description of Comment1",
				PostedOn = DateTime.Now,
				IsDeleted = false,
				EventId = Event1.Id,
				UserId = User.Id
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
			Exercise1 = new Exercise
			{
				Id = 1,
				ExerciseName = "Exercise1",
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

			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			  .UseInMemoryDatabase(databaseName: "ApplicationInMemoryDb" + Guid.NewGuid().ToString())
			  .Options;

			dbContext = new ApplicationDbContext(options);
			var userStore = new UserStore<ApplicationUser>(dbContext);
			userManager = new UserManager<ApplicationUser>(
				userStore, null, null, null, null, null, null, null, null);

			var roleStore = new RoleStore<IdentityRole>(dbContext);
			roleManager = new RoleManager<IdentityRole>(
				roleStore, null, null, null, null);

			// Create Roles
			if (!await roleManager.RoleExistsAsync(UserRole))
				await roleManager.CreateAsync(new IdentityRole(UserRole));

			if (!await roleManager.RoleExistsAsync(TrainerRole))
				await roleManager.CreateAsync(new IdentityRole(TrainerRole));

			await dbContext.AddAsync(User);
			await dbContext.AddAsync(Trainer);

			await dbContext.AddAsync(Event1);
			await dbContext.AddAsync(Comment1);

			await dbContext.AddAsync(Category);
			await dbContext.AddAsync(Program1);
			await dbContext.AddAsync(Exercise1);
			await dbContext.AddAsync(ProgramExercise1);
			await dbContext.AddAsync(Rating1);
			await dbContext.SaveChangesAsync();

			repository = new Repository(dbContext);


			await userManager.AddToRoleAsync(User, UserRole);
			await userManager.AddToRoleAsync(Trainer, TrainerRole);
			adminService = new AdminService(repository, userManager);
		}

		[TearDown]
		public async Task Teardown()
		{
			await dbContext.Database.EnsureDeletedAsync();
			await dbContext.DisposeAsync();
			userManager.Dispose();
			roleManager.Dispose();
		}


		[Test]
		public async Task AdminServiceShouldReturnPanelInformation()
		{
			// Arrange
			var panelInformation = new AdminPanelServiceModel
			{
				TotalUsers = 1,
				TotalTrainers = 1,
				TotalPrograms = 1,
				TotalEvents = 1,
				LatestEvents = await dbContext.Events.Where(e => e.IsDeleted == false)
					.OrderByDescending(x => x)
					.Take(15).Select(x => new AdminLatest15EventsServiceModel
					{
						TrainerFirstName = x.User.FirstName,
						TrainerLastName = x.User.LastName,
						EventTitle = x.Title,
						StartDate = x.StartDate.ToString(StartDateTimeFormat),
						StartHour = x.StartHour.ToString(StartHourTimeFormat),
						CommentsCount = x.Comments.Count()
					}).ToListAsync()
				,
				LatestPrograms = await dbContext.TrainingPrograms.Where(x => x.IsDeleted == false)
					.OrderByDescending(x => x)
					.Take(15).Select(x => new AdminLatest15ProgramsServiceModel
					{
						TrainerFirstName = x.User.FirstName,
						TrainerLastName = x.User.LastName,
						TrainingProgramCategory = x.Category.CategoryName,
						ExercisesCount = x.Exercises.Count(),
						Rating = x.Ratings.Any() == true ? x.Ratings.Average(r => r.Value) : 0
					}).ToListAsync()
			};
			// Act
			var result = await adminService.PanelInformationAsync();

			// Assert
			Assert.IsNotNull(result);
			Assert.IsNotNull(result.TotalUsers);
			Assert.IsNotNull(result.TotalPrograms);
			Assert.IsNotNull(result.TotalTrainers);
			Assert.IsNotNull(result.TotalEvents);
			Assert.IsNotNull(result.LatestEvents);
			Assert.IsNotNull(result.LatestPrograms);

			Assert.AreEqual(panelInformation.TotalUsers, result.TotalUsers);
			Assert.AreEqual(panelInformation.TotalTrainers, result.TotalTrainers);
			Assert.AreEqual(panelInformation.TotalPrograms, result.TotalPrograms);
			Assert.AreEqual(panelInformation.TotalEvents, result.TotalEvents);
			Assert.AreEqual(panelInformation.LatestEvents.Count, result.LatestEvents.Count);
			Assert.AreEqual(panelInformation.LatestPrograms.Count, result.LatestPrograms.Count);
			Assert.AreEqual(panelInformation.LatestEvents.First().TrainerFirstName, result.LatestEvents.First().TrainerFirstName);
			Assert.AreEqual(panelInformation.LatestEvents.First().TrainerLastName, result.LatestEvents.First().TrainerLastName);
			Assert.AreEqual(panelInformation.LatestEvents.First().EventTitle, result.LatestEvents.First().EventTitle);
			Assert.AreEqual(panelInformation.LatestEvents.First().StartDate, result.LatestEvents.First().StartDate);
			Assert.AreEqual(panelInformation.LatestEvents.First().StartHour, result.LatestEvents.First().StartHour);
			Assert.AreEqual(panelInformation.LatestEvents.First().CommentsCount, result.LatestEvents.First().CommentsCount);
			Assert.AreEqual(panelInformation.LatestPrograms.First().TrainerFirstName, result.LatestPrograms.First().TrainerFirstName);
			Assert.AreEqual(panelInformation.LatestPrograms.First().TrainerLastName, result.LatestPrograms.First().TrainerLastName);
			Assert.AreEqual(panelInformation.LatestPrograms.First().TrainingProgramCategory, result.LatestPrograms.First().TrainingProgramCategory);
			Assert.AreEqual(panelInformation.LatestPrograms.First().ExercisesCount, result.LatestPrograms.First().ExercisesCount);
			Assert.AreEqual(panelInformation.LatestPrograms.First().Rating, result.LatestPrograms.First().Rating);

		}
	}
}