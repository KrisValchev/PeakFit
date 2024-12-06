using Microsoft.AspNetCore.Identity;
using PeakFit.Core.Contracts;
using PeakFit.Infrastructure.Common;
using PeakFit.Infrastructure.Data.Models;
using PeakFit.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PeakFit.Core.Services;
using Moq;
using System.Runtime.Intrinsics.X86;
using PeakFit.Core.Constants;
using PeakFit.Core.Enumerations;

namespace PeakFit.Tests
{
	internal class ApplicationUserUnitTests
	{
		private ApplicationDbContext dbContext;

		private Mock<UserManager<ApplicationUser>> userManagerMock;
		private Mock<RoleManager<IdentityRole>> roleManagerMock;
		private IRepository repository;
		private IApplicationUserService applicationUserService;
		private ITrainingProgramService trainingProgramService;
		private IEventService eventService;

		private Event Event1;
		private Event Event2;

		private TrainingProgram Program1;
		private TrainingProgram Program2;

		private ApplicationUser User;
		private ApplicationUser User2;
		private ApplicationUser Trainer;
		private ApplicationUser Trainer2;
		private ApplicationUser Admin;

		private IdentityRole AdminRole;
		private IdentityRole UserRole;
		private IdentityRole TrainerRole;

		private Comment Comment1;
		private Comment Comment2;

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
			Admin = new ApplicationUser
			{
				Id = Guid.NewGuid().ToString(),
				UserName = "admin@gmail.com",
				NormalizedUserName = "admin@gmail.com",
				Email = "admin@gmail.com",
				NormalizedEmail = "admin@gmail.com",
				FirstName = "Admin",
				LastName = "Admin",
				PhoneNumber = "08777777777",
				Gender = "Male",
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
			Event2 = new Event
			{
				Id = 2,
				Title = "Event2",
				Description = "Description",
				StartDate = DateTime.Parse("18-12-2024"),
				StartHour = DateTime.Parse("10:00"),
				IsDeleted = false,
				UserId = Trainer2.Id,
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
			Comment2 = new Comment
			{
				Id = 2,
				Title = "Comment2",
				Description = "Description of Comment2",
				PostedOn = DateTime.Now,
				IsDeleted = false,
				EventId = Event2.Id,
				UserId = User2.Id
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

			UserProgram1= new UserProgram
			{
				UserId = User.Id,
				ProgramId = Program1.Id,
			};
			UserProgram2 = new UserProgram
			{
				UserId = User.Id,
				ProgramId = Program2.Id,
			};

			AdminRole = new IdentityRole
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Administrator",
				NormalizedName = "ADMINISTRATOR"
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

			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			  .UseInMemoryDatabase(databaseName: "ApplicationInMemoryDb" + Guid.NewGuid().ToString())
			  .Options;

			dbContext = new ApplicationDbContext(options);
			await dbContext.AddAsync(User);
			await dbContext.AddAsync(Trainer);
			await dbContext.AddAsync(User2);
			await dbContext.AddAsync(Trainer2);
			await dbContext.AddAsync(Admin);
			await dbContext.AddAsync(AdminRole);
			await dbContext.AddAsync(UserRole);
			await dbContext.AddAsync(TrainerRole);


			await dbContext.AddAsync(Event1);
			await dbContext.AddAsync(Event2);

			await dbContext.AddAsync(Comment1);
			await dbContext.AddAsync(Comment2);

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
			userManagerMock = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
			roleManagerMock = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);
			
			applicationUserService = new ApplicationUserService(repository, userManagerMock.Object);
			eventService = new EventService(repository);
			trainingProgramService = new TrainingProgramService(repository);

		}
		[TearDown]
		public async Task TearDown()
		{
			await dbContext.Database.EnsureDeletedAsync();
			await dbContext.DisposeAsync();
		}
		[Test]
		public async Task AllUsers_FilterByFirstName_ShouldReturnCorrectResult()
		{
			// Arrange
			var firstname = User.FirstName;

			// Act
			var result = await applicationUserService.AllUsersAsync(firstName: firstname);

			// Assert
			Assert.That(result.TotalUsersCount, Is.EqualTo(1));
		}
		[Test]
		public async Task AllUsers_FilterByLastName_ShouldReturnCorrectResult()
		{
			// Arrange
			var lastName = User.LastName;

			// Act
			var result = await applicationUserService.AllUsersAsync(lastName: lastName);

			// Assert
			Assert.That(result.TotalUsersCount, Is.EqualTo(1));
		}
		[Test]
		public async Task AllUsers_FilterBySortingEmailAscending_ShouldReturnCorrectResult()
		{
			// Act
			var sortingbyEmailAscending = await applicationUserService.AllUsersAsync(null, null, null, UserSorting.EmailAscending, 1, 5);

			var users = new List<string>()
			{
				sortingbyEmailAscending.Users.First().Email,
				sortingbyEmailAscending.Users.Skip(1).First().Email,
				sortingbyEmailAscending.Users.Skip(2).First().Email,
				sortingbyEmailAscending.Users.Skip(3).First().Email,
				sortingbyEmailAscending.Users.Last().Email
			};

			// Assert
			Assert.IsNotNull(sortingbyEmailAscending.Users);
			Assert.That(sortingbyEmailAscending.TotalUsersCount, Is.EqualTo(5));
			Assert.That(users, Is.EqualTo(new List<string>() { "admin@gmail.com", "trainer1@gmail.com", "trainer2@gmail.com", "user1@gmail.com","user2@gmail.com" }));
		}

		[Test]
		public async Task AllUsers_FilterBySortingEmailDescending_ShouldReturnCorrectResult()
		{
			// Act
			var sortingbyEmailDescending = await applicationUserService.AllUsersAsync(null, null, null, UserSorting.EmailDescending, 1, 5);

			var users = new List<string>()
			{
				sortingbyEmailDescending.Users.First().Email,
				sortingbyEmailDescending.Users.Skip(1).First().Email,
				sortingbyEmailDescending.Users.Skip(2).First().Email,
				sortingbyEmailDescending.Users.Skip(3).First().Email,
				sortingbyEmailDescending.Users.Last().Email

			};

			// Assert
			Assert.IsNotNull(sortingbyEmailDescending.Users);
			Assert.That(sortingbyEmailDescending.TotalUsersCount, Is.EqualTo(5));
			Assert.That(users, Is.EqualTo(new List<string>() { "user2@gmail.com" , "user1@gmail.com", "trainer2@gmail.com", "trainer1@gmail.com", "admin@gmail.com" }));
		}
		[Test]
		public async Task AllUsers_FilterBySortingFirstNameAscending_ShouldReturnCorrectResult()
		{
			// Act
			var sortingbyFirstNameAscending = await applicationUserService.AllUsersAsync(null, null, null, UserSorting.FirstNameAscending, 1, 5);

			var users = new List<string>()
			{
				sortingbyFirstNameAscending.Users.First().FirstName,
				sortingbyFirstNameAscending.Users.Skip(1).First().FirstName,
				sortingbyFirstNameAscending.Users.Skip(2).First().FirstName,
				sortingbyFirstNameAscending.Users.Skip(3).First().FirstName,
				sortingbyFirstNameAscending.Users.Last().FirstName
			};

			// Assert
			Assert.IsNotNull(sortingbyFirstNameAscending.Users);
			Assert.That(sortingbyFirstNameAscending.TotalUsersCount, Is.EqualTo(5));
			Assert.That(users, Is.EqualTo(new List<string>() { "Admin","Trainer1","Trainer2", "User1", "User2" }));
		}
		[Test]
		public async Task AllUsers_FilterBySortingFirstNameDescending_ShouldReturnCorrectResult()
		{
			// Act
			var sortingbyFirstNameDescending = await applicationUserService.AllUsersAsync(null, null, null, UserSorting.FirstNameDescending, 1, 5);

			var users = new List<string>()
			{
				sortingbyFirstNameDescending.Users.First().FirstName,
				sortingbyFirstNameDescending.Users.Skip(1).First().FirstName,
				sortingbyFirstNameDescending.Users.Skip(2).First().FirstName,
				sortingbyFirstNameDescending.Users.Skip(3).First().FirstName,
				sortingbyFirstNameDescending.Users.Last().FirstName
			};

			// Assert
			Assert.IsNotNull(sortingbyFirstNameDescending.Users);
			Assert.That(sortingbyFirstNameDescending.TotalUsersCount, Is.EqualTo(5));
			Assert.That(users, Is.EqualTo(new List<string>() { "User2", "User1", "Trainer2","Trainer1", "Admin" }));
		}

		[Test]
		public async Task AllUsers_FilterBySortingLastNameAscending_ShouldReturnCorrectResult()
		{
			// Act
			var sortingbyLastNameAscending = await applicationUserService.AllUsersAsync(null, null, null, UserSorting.LastNameAscending, 1, 5);

			var users = new List<string>()
			{
				sortingbyLastNameAscending.Users.First().LastName,
				sortingbyLastNameAscending.Users.Skip(1).First().LastName,
				sortingbyLastNameAscending.Users.Skip(2).First().LastName,
				sortingbyLastNameAscending.Users.Skip(3).First().LastName,
				sortingbyLastNameAscending.Users.Last().LastName
			};

			// Assert
			Assert.IsNotNull(sortingbyLastNameAscending.Users);
			Assert.That(sortingbyLastNameAscending.TotalUsersCount, Is.EqualTo(5));
			Assert.That(users, Is.EqualTo(new List<string>() { "Admin", "Trainer1", "Trainer2", "User1", "User2" }));
		}


		[Test]
		public async Task AllUsers_FilterBySortingLastNameDescending_ShouldReturnCorrectResult()
		{
			// Act
			var sortingbyLastNameDescending = await applicationUserService.AllUsersAsync(null, null, null, UserSorting.LastNameDescending, 1, 5);

			var users = new List<string>()
			{
				sortingbyLastNameDescending.Users.First().LastName,
				sortingbyLastNameDescending.Users.Skip(1).First().LastName,
				sortingbyLastNameDescending.Users.Skip(2).First().LastName,
				sortingbyLastNameDescending.Users.Skip(3).First().LastName,
				sortingbyLastNameDescending.Users.Last().LastName
			};

			// Assert
			Assert.IsNotNull(sortingbyLastNameDescending.Users);
			Assert.That(sortingbyLastNameDescending.TotalUsersCount, Is.EqualTo(5));
			Assert.That(users, Is.EqualTo(new List<string>() { "User2", "User1", "Trainer2", "Trainer1", "Admin" }));
		}
		[Test]
		public async Task DeleteAsync_ShouldDeleteUser()
		{
			// Arrange
			var userId = User2.Id;

			// Act
			await applicationUserService.DeleteAsync(userId);

			var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

			// Assert
			Assert.IsNull(user);
			Assert.That(dbContext.Users.Count(), Is.EqualTo(4));
			Assert.IsTrue(await applicationUserService.ExistsAsync(userId) == false);
		}
		//TODO: Fix the test
		//[Test]
		//public async Task DeleteAsync_ShouldDeleteUserAndLikedPrograms()
		//{
		//	// Arrange
		//	var userId = User.Id;

		//	// Act
		//	await applicationUserService.DeleteAsync(userId);

		//	var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

		//	// Assert
		//	Assert.IsNull(user);
		//	Assert.That(dbContext.Users.Count(), Is.EqualTo(4));
		//	Assert.IsTrue(await applicationUserService.ExistsAsync(userId) == false);
		//	Assert.That(dbContext.UsersPrograms.Count(), Is.EqualTo(0));

		//}

		[Test]
		public async Task DeleteAsync_ShouldDeleteTrainerAndTrainingPrograms()
		{
			// Arrange
			var trainerId = Trainer.Id;

			// Act
			await applicationUserService.DeleteAsync(trainerId);

			var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == trainerId);

			// Assert
			Assert.IsNull(user);
			Assert.That(dbContext.Users.Count(), Is.EqualTo(4));
			Assert.IsTrue(await applicationUserService.ExistsAsync(trainerId) == false);
			Assert.That(dbContext.TrainingPrograms.Count(), Is.EqualTo(1));
		}
		[Test]
		public async Task DeleteAsync_ShouldDeleteTrainerAndEvents()
		{
			// Arrange
			var trainerId = Trainer.Id;

			// Act
			await applicationUserService.DeleteAsync(trainerId);

			var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == trainerId);

			// Assert
			Assert.IsNull(user);
			Assert.That(dbContext.Users.Count(), Is.EqualTo(4));
			Assert.IsTrue(await applicationUserService.ExistsAsync(trainerId) == false);
			Assert.That(dbContext.Events.Count(), Is.EqualTo(1));
		}
		[Test]
		public async Task DeleteAsync_ShouldDeleteTrainerAndComments()
		{
			// Arrange
			var trainerId = Trainer.Id;

			// Act
			await applicationUserService.DeleteAsync(trainerId);

			var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == trainerId);

			// Assert
			Assert.IsNull(user);
			Assert.That(dbContext.Users.Count(), Is.EqualTo(4));
			Assert.IsTrue(await applicationUserService.ExistsAsync(trainerId) == false);
			Assert.That(dbContext.Comments.Count(), Is.EqualTo(1));
		}
		[Test]
		public async Task DeleteAsync_ShouldDeleteTrainerAndRatings()
		{
			// Arrange
			var trainerId = Trainer.Id;

			// Act
			await applicationUserService.DeleteAsync(trainerId);

			var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == trainerId);

			// Assert
			Assert.IsNull(user);
			Assert.That(dbContext.Users.Count(), Is.EqualTo(4));
			Assert.IsTrue(await applicationUserService.ExistsAsync(trainerId) == false);
			Assert.That(dbContext.Ratings.Count(), Is.EqualTo(0));
		}
		[Test]
		public async Task DeleteAsync_ShouldDeleteTrainerAndProgramExercises()
		{
			// Arrange
			var trainerId = Trainer.Id;

			// Act
			await applicationUserService.DeleteAsync(trainerId);

			var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == trainerId);

			// Assert
			Assert.IsNull(user);
			Assert.That(dbContext.Users.Count(), Is.EqualTo(4));
			Assert.IsTrue(await applicationUserService.ExistsAsync(trainerId) == false);
			Assert.That(dbContext.ProgramExercises.Count(), Is.EqualTo(1));
		}
		[Test]	
		public async Task DeleteAsync_ShouldDeleteTrainerAndUserPrograms()
		{
			// Arrange
			var trainerId = Trainer.Id;

			// Act
			await applicationUserService.DeleteAsync(trainerId);

			var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == trainerId);

			// Assert
			Assert.IsNull(user);
			Assert.That(dbContext.Users.Count(), Is.EqualTo(4));
			Assert.IsTrue(await applicationUserService.ExistsAsync(trainerId) == false);
			Assert.That(dbContext.UsersPrograms.Count(), Is.EqualTo(1));
		}
		[Test]
		public async Task ExistsAsync_ShouldReturnTrue()
		{
			// Arrange
			var userId = User.Id;
			// Act
			var result = await applicationUserService.ExistsAsync(userId);
			// Assert
			Assert.IsTrue(result);
		}
		[Test]
		public async Task ExistsAsync_ShouldReturnFalse()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();

			// Act
			var result = await applicationUserService.ExistsAsync(userId);
			// Assert
			Assert.IsFalse(result);
		}
		[Test]
		public async Task IsAdminAsync_ShouldReturnTrue()
		{
			// Arrange

			userManagerMock
				.Setup(m => m.IsInRoleAsync(It.IsAny<ApplicationUser>(), RoleConstants.AdminRole))
				.ReturnsAsync(true);

			// Act
			var result = await applicationUserService.IsAdminAsync(Admin.Id);
			Assert.IsTrue(result);
		}
		[Test]
		public async Task IsAdminAsync_ShouldReturnFalse()
		{
			// Arrange
			var userId = User.Id;
			// Act
			var result = await applicationUserService.IsAdminAsync(userId);
			// Assert
			Assert.IsFalse(result);
		}
		[Test]
		public async Task IsTrainerAsync_ShouldReturnTrue()
		{
			// Arrange

			userManagerMock
				.Setup(m => m.IsInRoleAsync(It.IsAny<ApplicationUser>(), RoleConstants.TrainerRole))
				.ReturnsAsync(true);

			// Act
			var result = await applicationUserService.IsTrainerAsync(Trainer.Id);
			// Assert
			Assert.IsTrue(result);
		}
		[Test]
		public async Task IsTrainerAsync_ShouldReturnFalse()
		{
			// Arrange
			var userId = User.Id;
			// Act
			var result = await applicationUserService.IsTrainerAsync(userId);
			// Assert
			Assert.IsFalse(result);
		}
		[Test]
		public async Task IsUserAsync_ShouldReturnTrue()
		{
			// Arrange

			userManagerMock
				.Setup(m => m.IsInRoleAsync(It.IsAny<ApplicationUser>(), RoleConstants.UserRole))
				.ReturnsAsync(true);

			// Act
			var result = await applicationUserService.IsUserAsync(User.Id);
			// Assert
			Assert.IsTrue(result);
		}
		[Test]
		public async Task IsUserAsync_ShouldReturnFalse()
		{
			// Arrange
			var userId = Trainer.Id;
			// Act
			var result = await applicationUserService.IsUserAsync(userId);
			// Assert
			Assert.IsFalse(result);
		}
		[Test]
		public async Task PromoteFromUserToAdminAsync_ShouldPromoteUserToAdmin()
		{
			// Arrange
			var userId = User.Id;
			var phoneNumber = "0888888888";
			userManagerMock
				.Setup(m => m.AddToRoleAsync(It.IsAny<ApplicationUser>(), RoleConstants.AdminRole))
				.ReturnsAsync(IdentityResult.Success);
			// Act
			await applicationUserService.PromoteFromUserToAdminAsync(userId, phoneNumber);
			// Assert
			// Assert
			userManagerMock.Verify(m => m.AddToRoleAsync(It.IsAny<ApplicationUser>(), RoleConstants.AdminRole), Times.Once);
		}
		[Test]
		public async Task PromoteFromTrainerToAdminAsync_ShouldPromoteTrainerToAdmin()
		{
			// Arrange
			var userId = Trainer.Id;
			userManagerMock
				.Setup(m => m.AddToRoleAsync(It.IsAny<ApplicationUser>(), RoleConstants.AdminRole))
				.ReturnsAsync(IdentityResult.Success);
			// Act
			await applicationUserService.PromoteFromTrainerToAdminAsync(userId);
			// Assert
			userManagerMock.Verify(m => m.AddToRoleAsync(It.IsAny<ApplicationUser>(), RoleConstants.AdminRole), Times.Once);
		}

		[Test]
		public async Task PhoneNumberExistsAsync_ShouldReturnTrue()
		{
			// Arrange
			var phoneNumber = Trainer.PhoneNumber;
			// Act
			var result = await applicationUserService.PhoneNumberExistsAsync(phoneNumber);
			// Assert
			Assert.IsTrue(result);
		}
		[Test]
		public async Task PhoneNumberExistsAsync_ShouldReturnFalse()
		{
			// Arrange
			var phoneNumber = "055555555";
			// Act
			var result = await applicationUserService.PhoneNumberExistsAsync(phoneNumber);
			// Assert
			Assert.IsFalse(result);
		}
		[Test]
		public async Task UserDetailsAsync_ShouldReturnCorrectResult()
		{
			// Arrange
			var userId = User.Id;
			// Act
			var result = await applicationUserService.UserDetailsAsync(userId);
			// Assert
			Assert.That(result.Id, Is.EqualTo(userId));
			Assert.That(result.FirstName, Is.EqualTo(User.FirstName));
			Assert.That(result.LastName, Is.EqualTo(User.LastName));
			Assert.That(result.Email, Is.EqualTo(User.Email));
			Assert.That(result.UserName, Is.EqualTo(User.UserName));

		}
	

	}
}
