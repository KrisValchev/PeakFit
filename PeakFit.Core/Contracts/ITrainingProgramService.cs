﻿using PeakFit.Core.Enumerations;
using PeakFit.Core.Models.CategoryModels;
using PeakFit.Core.Models.TrainingProgramModels;
using PeakFit.Infrastructure.Data.Models;


namespace PeakFit.Core.Contracts
{
    public interface ITrainingProgramService
    {
        Task<TrainingProgramQueryServiceModel> AllTrainingProgramsAsync(
            string? search = null,
            TrainingProgramSorting sorting = TrainingProgramSorting.Newest,
            int currentPage = 1,
            int trainingProgramsPerPage = 1,
            string? category = null);
        Task<TrainingProgramQueryServiceModel> MineTrainingProgramsAsync(
            ApplicationUser currentTrainer,
            int currentPage = 1,
            int trainingProgramsPerPage = 1);
        Task<TrainingProgramDetailsModel> DetailsAsync(int id);
        Task<bool> ExistAsync(int id);
        Task EditAsync(int id, EditTrainingProgramViewModel model);
        Task<int> AddAsync(AddTrainingProgramModel model, ApplicationUser trainer);
        Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync();
        Task<IEnumerable<string>> AllCategoriesNamesAsync();
        Task<IEnumerable<ProgramExercise>> CreateProgramExercisesFromAddTrainingProgramModelAsync(TrainingProgram trainingProgram, AddTrainingProgramModel model);
        Task<EditTrainingProgramViewModel> GetTrainingProgramFromEditTrainingProgramViewModelByIdAsync(int id);
        Task DeleteAsync(int id);
        Task AddToUsersProgramsAsync(int programId, ApplicationUser userId);
        Task<TrainingProgramQueryServiceModel> LikedProgramsAsync(ApplicationUser currentUser,
			int currentPage = 1,
			int trainingProgramsPerPage = 1);
        Task RemoveFromUsersProgramsAsync(int programId, ApplicationUser userId);
    }
}
