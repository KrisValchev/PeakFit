using PeakFit.Core.Contracts;
using PeakFit.Core.Models.EventModels;
using PeakFit.Infrastructure.Common;
using PeakFit.Infrastructure.Constraints;
using static PeakFit.Infrastructure.Constraints.EventDataConstraints;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PeakFit.Core.Services
{
    public class EventService(IRepository repository) : IEventService
    {
        // AllEvents Async method for displaying all events
        public async Task<IEnumerable<AllEventsInfoModel>> AllEventsAsync()
        {
            var events = repository.AllReadOnly<Event>().Where(e => e.IsDeleted == false);

            var allEvents = await events.Select(e => new AllEventsInfoModel()
            {
                Id = e.Id,
                TrainerId = e.UserId,
                Title = e.Title,
                StartDate = e.StartDate.ToString(StartDateTimeFormat),
                StartHour = e.StartHour.ToString(StartHourTimeFormat),
                ImageUrl = e.ImageUrl

            }).ToListAsync();
            return allEvents;
        }
        //DetailsAsync method is used to to get details about a event and it takes eventId as parameter and returns EventDetailsModel
        public async Task<EventDetailsModel> DetailsAsync(int id)
        {
            var events = repository.AllReadOnly<Event>().Where(e => e.IsDeleted == false && e.Id == id);
            var @event = await events.Select(e => new EventDetailsModel()
            {
                Id = e.Id,
                TrainerId = e.UserId,
                Title = e.Title,
                StartDate = e.StartDate.ToString(StartDateTimeFormat),
                StartHour = e.StartHour.ToString(StartHourTimeFormat),
                ImageUrl = e.ImageUrl,
                Description = e.Description,
                TrainerName=$"{e.User.FirstName} {e.User.LastName}"
            }).FirstOrDefaultAsync();
            return @event;
        }

        public async Task<bool> ExistAsync(int id)
        {
            if(await repository.GetByIdAsync<Event>(id) != null)
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
