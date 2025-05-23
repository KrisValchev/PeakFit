﻿using PeakFit.Core.Enumerations;
using PeakFit.Core.Models.EventModels;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PeakFit.Core.Contracts
{
    public interface IEventService
    {
         Task<EventQueryServiceModel> AllEventsAsync(
             string? search = null,
             EventSorting sorting = EventSorting.DateAscending,
             int currentPage = 1,
             int eventsPerPage = 1);
         Task<EventDetailsModel> DetailsAsync(int id);
        Task<bool> ExistAsync(int id);
        Task EditAsync(int id,EditEventModel model);
        Task<int> CreateAsync(AddEventsModel model,ApplicationUser trainer);
        Task<EditEventModel> GetEventFromEditEventViewModelByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
