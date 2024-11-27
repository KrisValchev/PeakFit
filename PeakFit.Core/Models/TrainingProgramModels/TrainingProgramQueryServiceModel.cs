using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Models.TrainingProgramModels
{
	public class TrainingProgramQueryServiceModel
	{
		public int TotalTrainingProgramsCount { get; set; }

		public IEnumerable<TrainingProgramServiceModel> TrainingPrograms { get; set; } = new List<TrainingProgramServiceModel>();
	}
}
