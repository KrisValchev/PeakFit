using PeakFit.Core.Models.CategoryModels;
using PeakFit.Core.Models.EventModels;
using PeakFit.Core.Models.TrainingProgramModels;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Contracts
{
    public interface ITrainingProgramService
    {
        Task<IEnumerable<AllTrainingProgramsInfoModel>> AllTrainingProgramsAsync();
        Task<TrainingProgramDetailsModel> DetailsAsync(int id);
        Task<bool> ExistAsync(int id);
        //Task EditAsync(int id, EditEventModel model);
        Task<int> AddAsync(AddTrainingProgramModel model, ApplicationUser trainer);
        Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync();
        //Task<EditEventModel> GetEventFromEditEventViewModelByIdAsync(int id);
        //Task DeleteAsync(int id);
    }
}
