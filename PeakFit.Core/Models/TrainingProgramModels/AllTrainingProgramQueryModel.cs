using PeakFit.Core.Enumerations;
using PeakFit.Core.Models.EventModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Models.TrainingProgramModels
{
	public class AllTrainingProgramQueryModel
	{
		[Display(Name = "Search by text")]
		public string Search { get; init; } = null!;
		public TrainingProgramSorting Sorting { get; init; }
		public int CurrentPage { get; init; } = 1;

		public int TotalTrainingProgramsCount { get; set; }
		public string Category { get; init; } = null!;
		public IEnumerable<string> Categories { get; set; } = null!;
		public IEnumerable<TrainingProgramServiceModel> TrainingPrograms { get; set; } = new List<TrainingProgramServiceModel>();

		public int TrainingProgramPerPage { get; set; } = 9;
	}
}
