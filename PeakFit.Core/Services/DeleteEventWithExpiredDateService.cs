using Microsoft.EntityFrameworkCore;
using PeakFit.Core.Contracts;
using PeakFit.Infrastructure.Common;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Services
{
    public class DeleteEventWithExpiredDateService(IRepository repository) : IDeleteEventWithExpiredDateService
    {
        //This method deletes events with expired dates
        public async Task DeleteExpiredEventsAsync()
        {
            var expiredEvents = await repository.All<Event>()
               .Where(e => e.StartDate < DateTime.Now) // Find events with dates in the past
               .ToListAsync();

            if (expiredEvents.Any())
            {
                foreach (var _event in expiredEvents)
                {
                    _event.IsDeleted = true;
                }
                await repository.SaveChangesAsync(); // Save changes to delete from the database
            }
        }
    }
}
