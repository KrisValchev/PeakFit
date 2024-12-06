using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeakFit.Core.Contracts;
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
	public class DeleteEventWithExpiredDateServiceUnitTests
	{
		private ApplicationDbContext dbContext;
		private IRepository repository;
		private IDeleteEventWithExpiredDateService deleteEventWithExpiredDateService;
		private Event Event1;
		private Event Event2;

		private ApplicationUser User;
		private ApplicationUser Trainer;

		private Comment Comment1;
		private Comment Comment2;

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
			Event2 = new Event
			{
				Id = 2,
				Title = "Event2",
				Description = "Description",
				StartDate = DateTime.Parse("18-11-2024"),
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
				EventId = Event2.Id,
				UserId = User.Id
			};
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			  .UseInMemoryDatabase(databaseName: "ApplicationInMemoryDb" + Guid.NewGuid().ToString())
			  .Options;

			dbContext = new ApplicationDbContext(options);
			await dbContext.AddAsync(User);
			await dbContext.AddAsync(Trainer);
			await dbContext.AddAsync(Event1);
			await dbContext.AddAsync(Event2);

			await dbContext.AddAsync(Comment1);
			await dbContext.AddAsync(Comment2);



			await dbContext.SaveChangesAsync();

			repository = new Repository(dbContext);
			deleteEventWithExpiredDateService = new DeleteEventWithExpiredDateService(repository);
			
		}
		[TearDown]
		public async Task Teardown()
		{
			await dbContext.Database.EnsureDeletedAsync();
			await dbContext.DisposeAsync();
		}
		[Test]
		public async Task DeleteExpiredEventsAsync_ShouldDeleteEventsWithExpiredDates()
		{
			await deleteEventWithExpiredDateService.DeleteExpiredEventsAsync();
			var events = await repository.All<Event>().ToListAsync();
			Assert.AreEqual(1, events.Where(e=>e.IsDeleted==false).Count());
			Assert.AreEqual(true, events[1].IsDeleted);
		}
		[Test]
		public async Task DeleteExpiredEventsAsync_ShouldDeleteCommentsOfEventsWithExpiredDates()
		{
			await deleteEventWithExpiredDateService.DeleteExpiredEventsAsync();
			var comments = await repository.All<Comment>().ToListAsync();
			Assert.AreEqual(1, comments.Where(c => c.IsDeleted == false).Count());
			Assert.AreEqual(true, comments[1].IsDeleted);
		}
		[Test]
		public async Task DeleteExpiredEventsAsync_ShouldNotDeleteEventsWithNotExpiredDates()
		{
			await deleteEventWithExpiredDateService.DeleteExpiredEventsAsync();
			var events = await repository.All<Event>().ToListAsync();
			Assert.AreEqual(1, events.Where(e => e.IsDeleted == false).Count());
			Assert.AreEqual(false, events[0].IsDeleted);
		}
		
	}
}
