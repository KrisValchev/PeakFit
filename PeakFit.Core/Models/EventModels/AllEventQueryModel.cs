using PeakFit.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace PeakFit.Core.Models.EventModels
{
	public class AllEventsQueryModel
	{
		[Display(Name = "Search by text")]
		public string Search { get; init; } = null!;

		public EventSorting Sorting { get; init; }
		public int CurrentPage { get; init; } = 1;

		public int TotalEventsCount { get; set; }

		public IEnumerable<EventServiceModel> Events { get; set; } = new List<EventServiceModel>();

		public int EventsPerPage { get; set; } = 8;

	}
}
