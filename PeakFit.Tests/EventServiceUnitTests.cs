using Microsoft.EntityFrameworkCore;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.EventModels;
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
	public class EventServiceUnitTests
	{
		private ApplicationDbContext dbContext;
		private IRepository repository;
		private IEventService eventService;

		private ApplicationUser User;
		private ApplicationUser Trainer;

		private Event Event1;
		private Event Event2;

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
			await dbContext.AddAsync(Event2);
			await dbContext.AddAsync(Comment1);
			await dbContext.AddAsync(Comment2);
			await dbContext.SaveChangesAsync();

			repository = new Repository(dbContext);
			eventService = new EventService(repository);
		}
		[TearDown]
		public async Task TearDown()
		{
			await dbContext.Database.EnsureDeletedAsync();
			await dbContext.DisposeAsync();
		}
		[Test]
		public async Task AllEventsAsync_ShouldReturnAllEvents()
		{
			var result = await eventService.AllEventsAsync();
			Assert.AreEqual(2, result.TotalEventsCount);

		}
		[Test]
		public async Task AllEventsAsync_ShouldReturnAllEvents_WhenEventIsDeleted()
		{
			Event1.IsDeleted = true;
			await dbContext.SaveChangesAsync();
			var result = await eventService.AllEventsAsync();
			Assert.AreEqual(1, result.TotalEventsCount);
		}
		[Test]
		public async Task GetEventDetailsByIdAsync_ShouldReturnEvent()
		{
			var result = await eventService.DetailsAsync(Event1.Id);
			Assert.AreEqual(Event1.Id, result.Id);
			Assert.AreEqual(Event1.Title, result.Title);
			Assert.AreEqual(Event1.Description, result.Description);
			Assert.AreEqual(Event1.StartDate, DateTime.Parse(result.StartDate));
			Assert.AreEqual(Event1.StartHour, DateTime.Parse(result.StartHour));
			Assert.AreEqual(Event1.UserId, result.TrainerId);
			Assert.AreEqual(Event1.ImageUrl, result.ImageUrl);
		}
		[Test]
		public async Task EditEventAsync_ShouldEditEvent()
		{
			var model = new EditEventModel
			{
				Id = Event1.Id,
				Title = "New Title",
				Description = "New Description",
				ImageUrl = "https://raceid.com/organizer/wp-content/uploads/2022/08/cost-marathon-featured-image-blog-10.png",
				StartDate = "17-12-2024",
				StartHour = "10:00"
			};
			await eventService.EditAsync(Event1.Id, model);
			var result = await eventService.DetailsAsync(Event1.Id);
			Assert.AreEqual(Event1.Id, result.Id);
			Assert.AreEqual(model.Title, result.Title);
			Assert.AreEqual(model.Description, result.Description);
			Assert.AreEqual(model.ImageUrl, result.ImageUrl);
			Assert.AreEqual(DateTime.Parse(model.StartDate), DateTime.Parse(result.StartDate));
			Assert.AreEqual(DateTime.Parse(model.StartHour), DateTime.Parse(result.StartHour));
		}
		[Test]
		public async Task ExistAsync_ShouldReturnTrue()
		{
			var result = await eventService.ExistAsync(Event1.Id);
			Assert.IsTrue(result);
		}
		[Test]
		public async Task ExistAsync_ShouldReturnFalse()
		{
			var result = await eventService.ExistAsync(100);
			Assert.IsFalse(result);
		}
		[Test]
		public async Task ExistAsync_ShouldReturnFalse_WhenEventIsDeleted()
		{
			Event1.IsDeleted = true;
			await dbContext.SaveChangesAsync();
			var result = await eventService.ExistAsync(Event1.Id);
			Assert.IsFalse(result);
		}
		[Test]
		public async Task CreateAsync_ShouldCreateEvent()
		{
			var model = new AddEventsModel
			{
				Title = "New Event",
				Description = "New Description",
				ImageUrl = "https://raceid.com/organizer/wp-content/uploads/2022/08/cost-marathon-featured-image-blog-10.png",
				StartDate = "17-12-2024",
				StartHour = "10:00"
			};
			var result = await eventService.CreateAsync(model, Trainer);
			Assert.AreEqual(3, result);
		}
		[Test]
		public async Task DeleteAsync_ShouldDeleteEvent()
		{
			await eventService.DeleteAsync(Event1.Id);
			var result = await eventService.ExistAsync(Event1.Id);
			Assert.IsFalse(result);
		}
		[Test]
		public async Task DeleteAsync_ShouldDeleteEventComments()
		{
			await eventService.DeleteAsync(Event1.Id);
			var result = await dbContext.Comments.Where(c => c.EventId == Event1.Id).ToListAsync();
			Assert.AreEqual(2, result.Count);
			Assert.IsTrue(result.All(c=>c.IsDeleted==true));
		}
		[Test]
		public async Task GetEventFromEditEventViewModelByIdAsync_ShouldReturnEditEventModel()
		{
			var result = await eventService.GetEventFromEditEventViewModelByIdAsync(Event1.Id);
			Assert.AreEqual(Event1.Id, result.Id);
			Assert.AreEqual(Event1.Title, result.Title);
			Assert.AreEqual(Event1.Description, result.Description);
			Assert.AreEqual(Event1.ImageUrl, result.ImageUrl);
			Assert.AreEqual(Event1.StartDate.ToString("dd-MM-yyyy"), result.StartDate);
			Assert.AreEqual(Event1.StartHour.ToString("HH:mm"), result.StartHour);
		}
		[Test]
		public async Task GetEventFromEditEventViewModelByIdAsync_ShouldReturnNull()
		{
			var result = await eventService.GetEventFromEditEventViewModelByIdAsync(100);
			Assert.IsNull(result);
		}
		[Test]
		public async Task GetEventFromEditEventViewModelByIdAsync_ShouldReturnNull_WhenEventIsDeleted()
		{
			Event1.IsDeleted = true;
			await dbContext.SaveChangesAsync();
			var result = await eventService.GetEventFromEditEventViewModelByIdAsync(Event1.Id);
			Assert.IsNull(result);
		}
	}
}
