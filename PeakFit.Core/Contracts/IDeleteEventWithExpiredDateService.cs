using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Contracts
{
    public interface IDeleteEventWithExpiredDateService
    {
        public Task DeleteExpiredEventsAsync();
    }
}
