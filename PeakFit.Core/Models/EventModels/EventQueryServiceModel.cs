using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PeakFit.Core.Models.EventModels
{
	public class EventQueryServiceModel
	{
		public int TotalEventsCount { get; set; }
       
        public IEnumerable<EventServiceModel> Events { get; set; } = new List<EventServiceModel>();
	}
}
