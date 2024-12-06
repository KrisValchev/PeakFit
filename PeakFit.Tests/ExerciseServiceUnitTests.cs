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
	public class ExerciseServiceUnitTests
	{
		private ApplicationDbContext dbContext;
		private IRepository repository;
		private IExerciseService exerciseService;
		private Category Category;
		private Exercise Exercise1;
		private Exercise Exercise2;

		[SetUp]
		public async Task Setup()
		{
			Category = new Category
			{
				Id = 1,
				CategoryName = "Category",
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
			

			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			  .UseInMemoryDatabase(databaseName: "ApplicationInMemoryDb" + Guid.NewGuid().ToString())
			  .Options;

			dbContext = new ApplicationDbContext(options);

			await dbContext.AddAsync(Category);

			await dbContext.AddAsync(Exercise1);
			await dbContext.AddAsync(Exercise2);

			await dbContext.SaveChangesAsync();
			repository = new Repository(dbContext);
			exerciseService = new ExerciseService(repository);
		}
		[TearDown]
		public async Task TearDown()
		{
			await dbContext.Database.EnsureDeletedAsync();
			await dbContext.DisposeAsync();
		}
		[Test]
		public async Task GetExercisesByCategoryAsync_ReturnsExercises()
		{
			var result = await exerciseService.GetExercisesByCategoryAsync(Category.Id);
			Assert.AreEqual(2, result.Count());
		}

	}
}
