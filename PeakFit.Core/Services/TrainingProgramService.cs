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

namespace PeakFit.Core.Services
{
    public class TrainingProgramService(IRepository repository) : ITrainingProgramService
    {
        public async Task<int> AddAsync(AddTrainingProgramModel model, ApplicationUser trainer)
        {
            TrainingProgram newProgram = new TrainingProgram
            {
                CategoryId = model.CategoryId,
                ImageUrl= model.ImageUrl,
                UserId= trainer.Id, 
                Exercises=model.Exercises.ToList()

            };

            await repository.AddAsync(newProgram);
            await repository.SaveChangesAsync();

            return newProgram.Id;
        }

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
                Rating =  p.Ratings.Average()

            }).ToListAsync();
            return allPrograms;
        }
        //DetailsAsync method is used to to get details about a program and it takes programId as parameter and returns TrainingProgramDetailsModel
        public async Task<TrainingProgramDetailsModel> DetailsAsync(int id)
        {
            var program= await repository.All<TrainingProgram>()
                .Where(p => p.Id == id)
                .Include(p=>p.Exercises)
                .Select(p => new TrainingProgramDetailsModel()
                {
                    Id = p.Id,
                    TrainerId = p.UserId,
                    TrainerName = $"{p.User.FirstName} {p.User.LastName}",
                    ImageUrl = p.ImageUrl,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.CategoryName,
                    Rating = p.Ratings.Average(),
                   Exercises= p.Exercises.Select(pe=>new ProgramExerciseViewModel
                   {
                       Id=pe.Id,
                       ExerciseName=pe.Exercise.ExerciseName,
                       Sets=pe.Sets,
                       Reps=pe.Reps,
                       ExerciseId=pe.ExerciseId,
                       ProgramId=pe.ProgramId
                   }).ToList()
                })
                .FirstAsync();

            return program;
        }
        //ExistAsync method is used to check if a program exists in the database and it takes programId as parameter and returns true if the program exists and false if it does not
        public async Task<bool> ExistAsync(int id)
        {
            var program = await repository.GetByIdAsync<TrainingProgram>(id);
            if (program.IsDeleted == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
