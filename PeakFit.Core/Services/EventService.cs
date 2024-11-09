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
using System.Globalization;


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
                TrainerUserName=e.User.UserName ?? string.Empty,
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
        // EditAsync method is used to edit a event in the database. It takes a eventId and EditEventModel as parameters. It gets the event by its id and updates its properties.
        public async Task EditAsync(int id,EditEventModel model)
        {

            
           var _event = await repository.GetByIdAsync<Event>(id);
            if (_event != null)
            {
                _event.Id= model.Id;  
                _event.Title= model.Title;
                _event.Description= model.Description;
                _event.ImageUrl= model.ImageUrl;
                _event.StartDate=DateTime.Parse(model.StartDate);
                _event.StartHour=DateTime.Parse(model.StartHour);
            }
                await repository.SaveChangesAsync();
        }
        //ExistAsync method is used to to check if event is existing or not ,and it takes eventId as parameter and returns bool
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
        // GetEventFromEditEventViewModelByIdAsync method is used to get a EditEventModel by its id. It takes a eventId as a parameter and returns a EditEventModel
        public async Task<EditEventModel> GetEventFromEditEventViewModelByIdAsync(int id)
        {

            var _event = await repository.AllReadOnly<Event>()
                .Where(e => e.IsDeleted == false && e.Id == id)
                .Select(e=>new EditEventModel { 
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                ImageUrl = e.ImageUrl,
                StartDate = e.StartDate.ToString(StartDateTimeFormat),
                StartHour = e.StartHour.ToString(StartHourTimeFormat),
            }).FirstOrDefaultAsync();
            return _event;
        }
    }
}
