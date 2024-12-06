using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
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
	public class ExpiredEventCleanUpServiceUnitTests
	{
		private ApplicationDbContext dbContext;
		private IServiceProvider serviceProvider;
		private IDeleteEventWithExpiredDateService deleteEventWithExpiredDateService;
		private IRepository repository;
		[SetUp]
		public async Task SetUp()
		{
			var services = new ServiceCollection();

			// Register required services
			services.AddScoped<IDeleteEventWithExpiredDateService, DeleteEventWithExpiredDateService>();
			services.AddScoped<IRepository, Repository>();

			// Register DbContext
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
				.EnableSensitiveDataLogging()
				.UseInMemoryDatabase(databaseName: "ApplicationInMemoryDb" + Guid.NewGuid())
				.Options;

			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseInMemoryDatabase("ApplicationInMemoryDb" + Guid.NewGuid()));

			serviceProvider = services.BuildServiceProvider();


			// Initialize DbContext and repository for direct access in tests
			dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
			repository = serviceProvider.GetRequiredService<IRepository>();
			deleteEventWithExpiredDateService = serviceProvider.GetRequiredService<IDeleteEventWithExpiredDateService>();

		}
		[TearDown]
		public async Task TearDown()
		{
			await dbContext.Database.EnsureDeletedAsync();
			await dbContext.DisposeAsync();

			if (serviceProvider is IDisposable disposable)
			{
				disposable.Dispose();
			}
		


		}
		[Test]
		public async Task ExecuteAsync_WhenCalled_ShouldDeleteExpiredEvents()
		{
			// Arrange
			var scope = serviceProvider.CreateScope();
			var scopedDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
			var myService = scope.ServiceProvider.GetRequiredService<IDeleteEventWithExpiredDateService>();
	
			var expiredEvents = new List<Event>
	{
		new Event { Id = 1, Title = "Event1", StartDate = DateTime.Now.AddDays(-1),Description="blablablabla",ImageUrl="https://raceid.com/organizer/wp-content/uploads/2022/08/cost-marathon-featured-image-blog-10.png" ,UserId=Guid.NewGuid().ToString() },
		new Event { Id = 2, Title = "Event2", StartDate = DateTime.Now.AddDays(-2),Description="blablablabla",ImageUrl="https://raceid.com/organizer/wp-content/uploads/2022/08/cost-marathon-featured-image-blog-10.png",UserId=Guid.NewGuid().ToString()   },
		new Event { Id = 3, Title = "Event3", StartDate = DateTime.Now.AddDays(-3),Description="blablablabla",ImageUrl="https://raceid.com/organizer/wp-content/uploads/2022/08/cost-marathon-featured-image-blog-10.png",UserId=Guid.NewGuid().ToString()  }
	};

			// Seed events into the DbContext
			await scopedDbContext.Events.AddRangeAsync(expiredEvents);
			await scopedDbContext.SaveChangesAsync();

			// Act
			await myService.DeleteExpiredEventsAsync();

			// Assert
			var remainingEvents = await scopedDbContext.Events.Where(e=>e.IsDeleted==true).ToListAsync();
			Assert.That(remainingEvents.Count, Is.EqualTo(3));
		}
		
	}
}

