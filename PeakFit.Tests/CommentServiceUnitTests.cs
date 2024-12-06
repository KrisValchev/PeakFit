using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.CommentModels;
using PeakFit.Core.Services;
using PeakFit.Infrastructure.Common;
using PeakFit.Infrastructure.Constraints;
using PeakFit.Infrastructure.Data.Models;
using PeakFit.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PeakFit.Infrastructure.Constraints.CommentDataConstraints;

namespace PeakFit.Tests
{
	[TestFixture]
	public class CommentServiceUnitTests
	{

		private ApplicationDbContext dbContext;
		private IRepository repository;
		private ICommentService commentService;

		private ApplicationUser User;
		private ApplicationUser Trainer;

		private Event Event1;

		private Comment Comment1;
		private Comment Comment2;


		[SetUp]
		public async Task Setup()
		{
			User = new ApplicationUser()
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

			Event1 = new Event()
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
			Comment2 = new Comment
			{
				Id = 2,
				Title = "Comment2",
				Description = "Description of Comment2",
				PostedOn = DateTime.Now,
				IsDeleted = false,
				EventId = Event1.Id,
				UserId = Trainer.Id
			};


			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			  .UseInMemoryDatabase(databaseName: "ApplicationInMemoryDb" + Guid.NewGuid().ToString())
			  .Options;

			dbContext = new ApplicationDbContext(options);
			await dbContext.AddAsync(User);
			await dbContext.AddAsync(Trainer);
			await dbContext.AddAsync(Event1);
			await dbContext.AddAsync(Comment1);
			await dbContext.AddAsync(Comment2);
			await dbContext.SaveChangesAsync();

			repository = new Repository(dbContext);
			commentService = new CommentService(repository);
		}
		[TearDown]
		public async Task TearDown()
		{
			await dbContext.Database.EnsureDeletedAsync();
			await dbContext.DisposeAsync();
		}
		[Test]
		public async Task AddAsync_ShouldAddComment()
		{
			// Arrange
			var model = new CommentAddViewModel
			{
				Title = "Comment3",
				Description = "Description of Comment3"
			};
			// Act
			await commentService.AddAsync(model, User, Event1.Id);
			// Assert
			var comment = await dbContext.Comments.LastOrDefaultAsync();
			Assert.AreEqual(3, dbContext.Comments.Count());
			Assert.AreEqual(model.Title, comment.Title);
			Assert.AreEqual(model.Description, comment.Description);
			Assert.AreEqual(User.Id, comment.UserId);
			Assert.AreEqual(Event1.Id, comment.EventId);
		}
		[Test]
		public async Task AllCommentsAsync_ShouldReturnAllComments()
		{
			// Act
			var comments = await commentService.AllCommentsAsync();
			// Assert
			Assert.AreEqual(2, comments.Count());
			Assert.AreEqual(Comment2.Title, comments.First().Title);
			Assert.AreEqual(Comment2.Description, comments.First().Description);
			Assert.AreEqual(Trainer.FirstName, comments.First().AuthorFirstName);
			Assert.AreEqual(Trainer.LastName, comments.First().AuthorLastName);
			Assert.AreEqual(Comment2.PostedOn.ToString(PostedOnDateTimeFormat), comments.First().PostedOn);
			Assert.AreEqual(Event1.Id, comments.First().EventId);
			Assert.AreEqual(Event1.Title, comments.First().EventName);
			Assert.AreEqual(Trainer.Id, comments.First().AuthorId);
		}
		[Test]
		public async Task CommentInformationByIdAsync_ShouldReturnComment()
		{
			// Act
			var comment = await commentService.CommentInformationByIdAsync(Comment1.Id);
			// Assert
			Assert.AreEqual(Comment1.Title, comment.Title);
			Assert.AreEqual(Comment1.Description, comment.Description);
			Assert.AreEqual(User.FirstName, comment.AuthorFirstName);
			Assert.AreEqual(User.LastName, comment.AuthorLastName);
			Assert.AreEqual(Comment1.PostedOn.ToString(PostedOnDateTimeFormat), comment.PostedOn);
			Assert.AreEqual(Event1.Id, comment.EventId);
			Assert.AreEqual(Event1.Title, comment.EventName);
			Assert.AreEqual(User.Id, comment.AuthorId);
		}
		[Test]
		public async Task DeleteAsync_ShouldDeleteComment()
		{
			// Act
			await commentService.DeleteAsync(Comment1.Id);
			// Assert
			var comment = await dbContext.Comments.FindAsync(Comment1.Id);
			Assert.IsTrue(comment.IsDeleted);
		}

		[Test]
		public async Task ExistsAsync_ShouldReturnTrue_WhenCommentExists()
		{
			// Act
			var result = await commentService.ExistsAsync(Comment1.Id);
			// Assert
			Assert.IsTrue(result);
		}
		[Test]
		public async Task ExistsAsync_ShouldReturnFalse_WhenCommentDoesNotExist()
		{
			// Act
			var result = await commentService.ExistsAsync(3);
			// Assert
			Assert.IsFalse(result);
		}
		[Test]
		public async Task ExistsAsync_ShouldReturnFalse_WhenCommentIsDeleted()
		{
			// Arrange
			Comment1.IsDeleted = true;
			await dbContext.SaveChangesAsync();
			// Act
			var result = await commentService.ExistsAsync(Comment1.Id);
			// Assert
			Assert.IsFalse(result);
		}
	

	}
}
