using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Models.AdminModels
{
	public class AdminLatest15EventsServiceModel
	{
		public string TrainerFirstName { get; set; } = null!;
		public string TrainerLastName { get; set; } = null!;
		public string EventTitle { get; set; } = null!;
		public string StartDate { get; set; } = null!;
		public string StartHour { get; set; } = null!;

		public int CommentsCount { get; set; }
	}
}
