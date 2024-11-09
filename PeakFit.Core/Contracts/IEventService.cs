using PeakFit.Core.Models.EventModels;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PeakFit.Core.Models.EventModels.AllEventsInfoModel;
namespace PeakFit.Core.Contracts
{
    public interface IEventService
    {
         Task<IEnumerable<AllEventsInfoModel>> AllEventsAsync();
         Task<EventDetailsModel> DetailsAsync(int id);
        Task<bool> ExistAsync(int id);
        Task EditAsync(int id,EditEventModel model);
        Task<int> CreateAsync(AddEventModel model,ApplicationUser trainer);
        Task<EditEventModel> GetEventFromEditEventViewModelByIdAsync(int id);
    }
}
