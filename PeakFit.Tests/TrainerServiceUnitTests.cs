using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moq;
using PeakFit.Core.Constants;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.TrainerModels;
using PeakFit.Core.Services;
using PeakFit.Infrastructure.Common;
using PeakFit.Infrastructure.Data.Models;
using PeakFit.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static PeakFit.Core.Constants.RoleConstants;

namespace PeakFit.Tests
{
	[TestFixture]
	public class TrainerServiceUnitTests
	{
		private ApplicationDbContext dbContext;
		private UserManager<ApplicationUser> userManager;
		private RoleManager<IdentityRole> roleManager;
		private Mock<UserManager<ApplicationUser>> userManagerMock;
		private Mock<RoleManager<IdentityRole>> roleManagerMock;
		private IRepository repository;
		private ITrainerService trainerService;

		private ApplicationUser User;
		private ApplicationUser User2;
		private ApplicationUser Trainer;
		private ApplicationUser Trainer2;

		private IdentityRole UserRole;
		private IdentityRole TrainerRole;

		private TrainingProgram Program1;

		private Category Category;

		private Rating Rating1;
		private Rating Rating2;

		private Exercise Exercise1;
		private Exercise Exercise2;

		private ProgramExercise ProgramExercise1;
		private ProgramExercise ProgramExercise2;

		private UserProgram UserProgram1;

		[SetUp]
		public async Task SetUp()
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
			Trainer2 = new ApplicationUser
			{
				Id = Guid.NewGuid().ToString(),
				UserName = "trainer2@gmail.com",
				NormalizedUserName = "trainer2@gmail.com",
				Email = "trainer2@gmail.com",
				NormalizedEmail = "trainer2@gmail.com",
				FirstName = "Trainer2",
				LastName = "Trainer2",
				PhoneNumber = "08888098888",
				Gender = "Female",
			};
			UserRole = new IdentityRole
			{
				Id = Guid.NewGuid().ToString(),
				Name = "User",
				NormalizedName = "USER"
			};
			TrainerRole = new IdentityRole
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Trainer",
				NormalizedName = "TRAINER"
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
			UserProgram1 = new UserProgram
			{
				UserId = User.Id,
				ProgramId = Program1.Id,
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
			if (!await roleManager.RoleExistsAsync(RoleConstants.UserRole))
				await roleManager.CreateAsync(new IdentityRole(RoleConstants.UserRole));

			if (!await roleManager.RoleExistsAsync(RoleConstants.TrainerRole))
				await roleManager.CreateAsync(new IdentityRole(RoleConstants.TrainerRole));

			await dbContext.AddAsync(User);
			await dbContext.AddAsync(Trainer);
			await dbContext.AddAsync(User2);
			await dbContext.AddAsync(Trainer2);
			await dbContext.AddAsync(UserRole);
			await dbContext.AddAsync(TrainerRole);
			await dbContext.AddAsync(Category);

			await dbContext.AddAsync(Program1);

			await dbContext.AddAsync(Exercise1);
			await dbContext.AddAsync(Exercise2);

			await dbContext.AddAsync(ProgramExercise1);
			await dbContext.AddAsync(ProgramExercise2);
			await dbContext.AddAsync(Rating1);
			await dbContext.AddAsync(Rating2);

			await dbContext.AddAsync(UserProgram1);
			await dbContext.SaveChangesAsync();

			repository = new Repository(dbContext);
			userManagerMock = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
			roleManagerMock = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);
			await userManager.AddToRoleAsync(User, RoleConstants.UserRole);
			await userManager.AddToRoleAsync(Trainer, RoleConstants.TrainerRole);

			trainerService = new TrainerService(repository, userManager,roleManager);


		}
		[TearDown]
		public async Task TearDown()
		{
			await dbContext.Database.EnsureDeletedAsync();
			await dbContext.DisposeAsync();
			userManager.Dispose();
			roleManager.Dispose();
		}
		[Test]
		public async Task AddPhoneNumberAsync_ShouldAddPhoneNumberToTrainer()
		{
			//Arrange
			var model = new BecomeTrainerModel
			{
				PhoneNumber = "0888888888"
			};
			 userManagerMock.Setup(x => x.IsInRoleAsync(Trainer, RoleConstants.UserRole)).ReturnsAsync(true);
			
			//Act
			await trainerService.AddPhoneNumberAsync(Trainer.Id, model);
			//Assert
			Assert.AreEqual("0888888888", Trainer.PhoneNumber);

		}
		[Test]
		public async Task AddPhoneNumberAsync_ShouldChangeUserRoleToTrainerRole()
		{
			//Arrange
			var model = new BecomeTrainerModel
			{
				PhoneNumber = "0888888888"
			};
			userManagerMock.Setup(x => x.IsInRoleAsync(Trainer, RoleConstants.UserRole)).ReturnsAsync(true);
			roleManagerMock.Setup(x => x.FindByNameAsync(RoleConstants.TrainerRole)).ReturnsAsync(TrainerRole);
			//Act
			await trainerService.AddPhoneNumberAsync(Trainer.Id, model);
			//Assert
			userManagerMock.Verify(x => x.RemoveFromRoleAsync(Trainer, RoleConstants.UserRole), Times.Once);
			userManagerMock.Verify(x => x.AddToRoleAsync(Trainer, RoleConstants.TrainerRole), Times.Once);
		}
		[Test]
		public async Task IsInTrainerRoleAsync_ShouldReturnTrueIfUserIsInTrainerRole()
		{
			//Arrange
			var userId = Trainer.Id;

			//Act
			var result = await trainerService.IsInTrainerRoleAsync(userId);
			//Assert
			Assert.IsTrue(result);
		}
		[Test]
		public async Task IsInTrainerRoleAsync_ShouldReturnFalseIfUserIsNotInTrainerRole()
		{
			//Arrange
			var userId = User.Id;
			//Act
			var result = await trainerService.IsInTrainerRoleAsync(userId);
			//Assert
			Assert.IsFalse(result);
		}
		[Test]
		public async Task RemoveLikedPrograms_ShouldRemoveAllLikedPrograms()
		{
			//Arrange
			var userId = User.Id;
			//Act
			await trainerService.RemoveLikedPrograms(userId);
			//Assert
			Assert.AreEqual(0, dbContext.UsersPrograms.Count());

		}
		[Test]
		public async Task UserWithPhoneNumberExistsAsync_ShouldReturnTrueIfUserWithPhoneNumberExists()
		{
			//Arrange
			var phoneNumber = Trainer.PhoneNumber;
			//Act
			var result = await trainerService.UserWithPhoneNumberExistsAsync(phoneNumber);
			//Assert
			Assert.IsTrue(result);
		}
		[Test]
		public async Task UserWithPhoneNumberExistsAsync_ShouldReturnFalseIfUserWithPhoneNumberDoesNotExists()
		{
			//Arrange
			var phoneNumber = "0888888889";
			//Act
			var result = await trainerService.UserWithPhoneNumberExistsAsync(phoneNumber);
			//Assert
			Assert.IsFalse(result);
		}

		

	}
}
