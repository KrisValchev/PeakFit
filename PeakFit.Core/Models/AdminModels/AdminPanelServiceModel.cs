using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Models.AdminModels
{
	public class AdminPanelServiceModel
	{
		public int TotalUsers { get; set; }
		public int TotalTrainers { get; set; }

		public int TotalEvents { get; set; }
		public int TotalPrograms { get; set; }

		public int TotalComments { get; set; }

		public ICollection<AdminLatest15EventsServiceModel> LatestEvents { get; set; } = new List<AdminLatest15EventsServiceModel>();
        public ICollection<AdminLatest15ProgramsServiceModel> LatestPrograms { get; set; } = new List<AdminLatest15ProgramsServiceModel>();
    }
}
