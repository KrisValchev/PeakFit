using Microsoft.EntityFrameworkCore;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.CategoryModels;
using PeakFit.Core.Models.EventModels;
using PeakFit.Core.Models.TrainingProgramModels;
using PeakFit.Infrastructure.Common;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PeakFit.Core.Models.ExerciseModels;
using PeakFit.Core.Models.ProgramExerciseModels;
using PeakFit.Core.Enumerations;
using System.Text.Json.Serialization;

namespace PeakFit.Core.Services
{

	public class TrainingProgramService(IRepository repository) : ITrainingProgramService
	{

		//AddAsync method is used to add a new training program and it takes AddTrainingProgramModel and ApplicationUser as parameters and returns the id of the new program
		public async Task<int> AddAsync(AddTrainingProgramModel model, ApplicationUser trainer)
		{
			TrainingProgram newProgram = new TrainingProgram
			{

				CategoryId = model.CategoryId,
				ImageUrl = model.ImageUrl,
				UserId = trainer.Id,
				Ratings = new List<Rating>(),
				Exercises = new List<ProgramExercise>()
			};

			await repository.AddAsync<TrainingProgram>(newProgram);
			await repository.SaveChangesAsync();
			var programExercises = await CreateProgramExercisesFromAddTrainingProgramModelAsync(newProgram, model);

			return newProgram.Id;
		}
		//CreateProgramExercisesFromAddTrainingProgramModelAsync method is used to create program exercises from AddTrainingProgramModel and it takes TrainingProgram and AddTrainingProgramModel as parameters and returns IEnumerable of ProgramExercise
		public async Task<IEnumerable<ProgramExercise>> CreateProgramExercisesFromAddTrainingProgramModelAsync(TrainingProgram trainingProgram, AddTrainingProgramModel model)
		{
			List<ProgramExercise> programExercises = new List<ProgramExercise>();
			var programExercisesModelList = model.ProgramExercises.Select(pe => new ProgramExerciseAddModel
			{
				ExerciseId = pe.ExerciseId,
				Sets = pe.Sets,
				Reps = pe.Reps
			}).ToList();
			await CreatingProgramExercisesAndAddingThemToTrainingProgramById(programExercisesModelList, trainingProgram);
			return programExercises;
		}
		//AllCategoriesAsync method is used to display all categories
		public async Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync()
		{
			return await repository.AllReadOnly<Category>()
			   .Select(ct => new CategoryViewModel()
			   {
				   Id = ct.Id,
				   CategoryName = ct.CategoryName
			   })
			   .ToListAsync();
		}
		//AllTrainingProgramsAsync method is used to display all training programs
		public async Task<TrainingProgramQueryServiceModel> AllTrainingProgramsAsync(
			string? search = null,
			TrainingProgramSorting sorting = TrainingProgramSorting.Newest,
			int currentPage = 1,
			int trainingProgramsPerPage = 1,
			string? category = null)
		{
			var programs = repository.AllReadOnly<TrainingProgram>().Where(p => p.IsDeleted == false);

			if (category != null)
			{
				programs = programs
				   .Where(p => p.Category.CategoryName == category);
			}
			if (search != null)
			{
				string searchToLower = search.ToLower();
				programs = programs
					.Where(p => (p.Category.CategoryName.ToLower().Contains(searchToLower)));
			}

			programs = sorting switch
			{
				TrainingProgramSorting.ByRatingAscending => programs
					.OrderBy(p => p.Ratings.Average(r => r.Value)),
				TrainingProgramSorting.ByRatingDescending => programs
					.OrderByDescending(p => p.Ratings.Average(r => r.Value)),
				TrainingProgramSorting.Newest => programs
					.OrderBy(p => p.Id),
				TrainingProgramSorting.Oldest => programs
				   .OrderByDescending(p => p.Id)
			};
			var allPrograms = await programs
				.Skip((currentPage - 1) * trainingProgramsPerPage)
				.Take(trainingProgramsPerPage)
				.Select(p => new TrainingProgramServiceModel()
				{
					Id = p.Id,
					TrainerId = p.UserId,
					TrainerUserName = $"{p.User.FirstName} {p.User.LastName}",
					ImageUrl = p.ImageUrl,
					CategoryId = p.CategoryId,
					CategoryName = p.Category.CategoryName,
					Ratings = p.Ratings,
					UserProgram = p.UsersPrograms.ToList(),
					ExerciseCount = p.Exercises.Count(),

				}).ToListAsync();
			int trainingProgramsCount = await programs.CountAsync();

			return new TrainingProgramQueryServiceModel()
			{
				TrainingPrograms = allPrograms,
				TotalTrainingProgramsCount = trainingProgramsCount
			};
		}
		//DetailsAsync method is used to to get details about a program and it takes programId as parameter and returns TrainingProgramDetailsModel
		public async Task<TrainingProgramDetailsModel> DetailsAsync(int id)
		{
			var program = await repository.AllReadOnly<TrainingProgram>()
				.Where(p => p.Id == id)
				.Include(p => p.Exercises)
				.Select(p => new TrainingProgramDetailsModel()
				{
					Id = p.Id,
					TrainerId = p.UserId,
					TrainerName = $"{p.User.FirstName} {p.User.LastName}",
					ImageUrl = p.ImageUrl,
					CategoryId = p.CategoryId,
					CategoryName = p.Category.CategoryName,
					Ratings = p.Ratings,
					Exercises = p.Exercises.Select(pe => new ProgramExerciseDetailsViewModel
					{
						Id = pe.Id,
						ExerciseName = pe.Exercise.ExerciseName,
						Sets = pe.Sets,
						Reps = pe.Reps
					}).ToList(),
					UserProgram = p.UsersPrograms.ToList()
				})
				.FirstAsync();

			return program;
		}
		//ExistAsync method is used to check if a program exists in the database and it takes programId as parameter and returns true if the program exists and false if it does not
		public async Task<bool> ExistAsync(int id)
		{
			var program = await repository.GetByIdAsync<TrainingProgram>(id);
			if (program != null)
			{
				if (program.IsDeleted == false)
				{
					return true;
				}
				return false;
			}
			else
			{
				return false;
			}
		}
		//EditAsync method is used to edit a program in the database. It takes a programId and EditTrainingProgramViewModel as parameters. It gets the program by its id and updates its properties.
		public async Task EditAsync(int id, EditTrainingProgramViewModel model)
		{
			var program = await repository.AllReadOnly<TrainingProgram>()
				.Where(tp => tp.Id == id && tp.IsDeleted == false)
				.Include(tp => tp.Exercises)
				.FirstOrDefaultAsync();
			if (program != null)
			{
				await DeleteCurrentExercisesFromTrainingProgram(program);
				program.Id = model.Id;
				program.ImageUrl = model.ImageUrl;
				await CreatingProgramExercisesAndAddingThemToTrainingProgramById(model.ProgramExercises, program);
			}
			await repository.SaveChangesAsync();
		}
		//CreatingProgramExercisesAndAddingThemToTrainingProgramById method is used to create program exercises and add them to a training program by its id. It takes IEnumerable of ProgramExerciseAddModel and TrainingProgram as parameters
		private async Task CreatingProgramExercisesAndAddingThemToTrainingProgramById(IEnumerable<ProgramExerciseAddModel> programExercises, TrainingProgram program)
		{

			foreach (var programExercise in programExercises)
			{

				var newProgramExercise = new ProgramExercise
				{
					Sets = programExercise.Sets,
					Reps = programExercise.Reps,
					ExerciseId = programExercise.ExerciseId,
					ProgramId = program.Id

				};

				program.Exercises.Add(newProgramExercise);
				await repository.AddAsync<ProgramExercise>(newProgramExercise);
			}
			await repository.SaveChangesAsync();
		}
		//GetTrainingProgramFromEditTrainingProgramViewModelByIdAsync method is used to get a EditTrainingProgramViewModel by its id. It takes a programId as a parameter and returns a EditTrainingProgramViewModel
		public async Task<EditTrainingProgramViewModel> GetTrainingProgramFromEditTrainingProgramViewModelByIdAsync(int id)
		{
			var program = await repository.AllReadOnly<TrainingProgram>()
			   .Where(e => e.IsDeleted == false && e.Id == id)
			   .Select(e => new EditTrainingProgramViewModel
			   {
				   Id = e.Id,
				   ImageUrl = e.ImageUrl,
				   CategoryId = e.CategoryId,
				   ProgramExercises = e.Exercises.Select(pe => new ProgramExerciseAddModel
				   {
					   Id = pe.Id,
					   ExerciseId = pe.ExerciseId,
					   Sets = pe.Sets,
					   Reps = pe.Reps
				   }).ToList()
			   }).FirstOrDefaultAsync();
			return program;
		}

		//DeleteCurrentExercisesFromTrainingProgram method is used to delete current exercises from a training program. It takes a TrainingProgram as a parameter
		public async Task DeleteCurrentExercisesFromTrainingProgram(TrainingProgram program)
		{

			foreach (var exercise in program.Exercises)
			{

				await repository.DeleteAsync<ProgramExercise>(exercise.Id);

			}
			program.Exercises.Clear();
			await repository.SaveChangesAsync();
		}
		//MineTrainingProgramsAsync method is used to display all programs that the current user has created
		public async Task<TrainingProgramQueryServiceModel> MineTrainingProgramsAsync(
			ApplicationUser currentTrainer,
			int currentPage = 1,
			int trainingProgramsPerPage = 1)
		{
			var programs = repository.AllReadOnly<TrainingProgram>()
				.Where(tp => tp.UserId == currentTrainer.Id && tp.IsDeleted == false);

			var allMinePrograms = await programs
				.Skip((currentPage - 1) * trainingProgramsPerPage)
				.Take(trainingProgramsPerPage)
				.Select(tp => new TrainingProgramServiceModel()
				{
					Id = tp.Id,
					TrainerId = tp.UserId,
					TrainerUserName = $"{tp.User.FirstName} {tp.User.LastName}",
					ImageUrl = tp.ImageUrl,
					CategoryId = tp.CategoryId,
					CategoryName = tp.Category.CategoryName,
					Ratings = tp.Ratings,
					ExerciseCount = tp.Exercises.Count(),
				}).ToListAsync();
			int trainingProgramsCount = await programs.CountAsync();

			return new TrainingProgramQueryServiceModel()
			{
				TrainingPrograms = allMinePrograms,
				TotalTrainingProgramsCount = trainingProgramsCount
			};
		}
		//DeleteAsync method is used to delete a program from the database. It takes a programId as a parameter and sets the IsDeleted property of the program to true
		public async Task DeleteAsync(int id)
		{

			var program = await repository.GetByIdAsync<TrainingProgram>(id);
			if (program != null)
			{
				program.IsDeleted = true;
				await repository.SaveChangesAsync();
			}
		}
		//AddToUsersProgramsAsync method is used to add a program to a user's programs. It takes a programId and ApplicationUser as parameters
		public async Task AddToUsersProgramsAsync(int programId, ApplicationUser userId)
		{
			UserProgram programUser = new UserProgram
			{
				ProgramId = programId,
				UserId = userId.Id
			};
			await repository.AddAsync<UserProgram>(programUser);
			await repository.SaveChangesAsync();
		}
		//LikedProgramsAsync method is used to display all programs that the current user has liked
		public async Task<TrainingProgramQueryServiceModel> LikedProgramsAsync(ApplicationUser currentUser,
			int currentPage = 1,
			int trainingProgramsPerPage = 1)
		{
			var programs = repository.AllReadOnly<UserProgram>()
			  .Where(r => r.UserId == currentUser.Id);

			var likedPrograms = await programs
				.Skip((currentPage - 1) * trainingProgramsPerPage)
				.Take(trainingProgramsPerPage)
			  .Select(p => new TrainingProgramServiceModel()
			  {
				  Id = p.ProgramId,
				  TrainerId = p.Program.UserId,
				  TrainerUserName = $"{p.User.FirstName} {p.User.LastName}",
				  ImageUrl = p.Program.ImageUrl,
				  CategoryId = p.Program.CategoryId,
				  CategoryName = p.Program.Category.CategoryName,
				  Ratings = p.Program.Ratings,
				  ExerciseCount= p.Program.Exercises.Count()

			  }).ToListAsync();
			int likedProgramsCount = await programs.CountAsync();

			return new TrainingProgramQueryServiceModel()
			{
				TrainingPrograms = likedPrograms,
				TotalTrainingProgramsCount = likedProgramsCount
			};
		}
		//RemoveFromUsersProgramsAsync method is used to remove a program from a user's programs. It takes a programId and ApplicationUser as parameters
		public async Task RemoveFromUsersProgramsAsync(int programId, ApplicationUser userId)
		{
			UserProgram userProgram = new UserProgram
			{
				ProgramId = programId,
				UserId = userId.Id
			};
			await repository.RemoveAsync(userProgram);

			await repository.SaveChangesAsync();
		}
		//AllCategoriesNamesAsync method is used to display all categories names
		public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
		{
			return await repository.AllReadOnly<Category>()
				.Select(ct => ct.CategoryName)
				.ToListAsync();
		}
	}
}
