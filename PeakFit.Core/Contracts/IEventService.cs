using PeakFit.Core.Models.EventModels;
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
        public Task<IEnumerable<AllEventsInfoModel>> AllEventsAsync();
    }
}
