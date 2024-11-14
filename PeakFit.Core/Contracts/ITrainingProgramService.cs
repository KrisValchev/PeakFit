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
        //Task<EventDetailsModel> DetailsAsync(int id);
        //Task<bool> ExistAsync(int id);
        //Task EditAsync(int id, EditEventModel model);
        //Task<int> CreateAsync(AddEventModel model, ApplicationUser trainer);
        //Task<EditEventModel> GetEventFromEditEventViewModelByIdAsync(int id);
        //Task DeleteAsync(int id);
    }
}
