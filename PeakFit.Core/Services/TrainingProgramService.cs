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
				Ratings = new List<double>() { 0 },
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
		public async Task<IEnumerable<AllTrainingProgramsInfoModel>> AllTrainingProgramsAsync()
		{
			var programs = repository.AllReadOnly<TrainingProgram>().Where(p => p.IsDeleted == false);

			var allPrograms = await programs.Select(p => new AllTrainingProgramsInfoModel()
			{
				Id = p.Id,
				TrainerId = p.UserId,
				TrainerUserName = $"{p.User.FirstName} {p.User.LastName}",
				ImageUrl = p.ImageUrl,
				CategoryId = p.CategoryId,
				CategoryName = p.Category.CategoryName,
				Rating = p.Ratings.Average()

			}).ToListAsync();
			return allPrograms;
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
					Rating = p.Ratings.Average(),
					Exercises = p.Exercises.Select(pe => new ProgramExerciseDetailsViewModel
					{
						Id = pe.Id,
						ExerciseName = pe.Exercise.ExerciseName,
						Sets = pe.Sets,
						Reps = pe.Reps
					}).ToList()
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
		//MineTrainingProgramsAsync method is used to display all training programs of the current trainer
		public async Task<IEnumerable<AllTrainingProgramsInfoModel>> MineTrainingProgramsAsync(ApplicationUser currentTrainer)
		{
			return await repository.AllReadOnly<TrainingProgram>()
				.Where(tp => tp.UserId == currentTrainer.Id && tp.IsDeleted == false)
				.Select(tp => new AllTrainingProgramsInfoModel
				{
					Id = tp.Id,
					TrainerId = tp.UserId,
					TrainerUserName = $"{tp.User.FirstName} {tp.User.LastName}",
					ImageUrl = tp.ImageUrl,
					CategoryId = tp.CategoryId,
					CategoryName = tp.Category.CategoryName,
					Rating = tp.Ratings.Average()
				}).ToListAsync();
		}
	}
}
