using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Models.TrainingProgramModels
{
	public class TrainingProgramServiceModel
	{
		[Display(Name = "Program identifier")]
		public int Id { get; set; }
		[Display(Name = "Program category identifier")]
		public int CategoryId { get; set; }
		[Display(Name = "Program category title")]
		public string CategoryName { get; set; } = null!;
		[Display(Name = "Program image")]
		public string ImageUrl { get; set; } = null!;
		[Display(Name = "Trainer identifier")]
		public string TrainerId { get; set; } = null!;
		[Display(Name = "Trainer username")]
		public string TrainerUserName { get; set; } = null!;
		[Display(Name = "Program rating")]
		public IList<Rating> Ratings { get; set; } = new List<Rating>();
		[Display(Name = "Users that liked this program")]
		public IList<UserProgram >UserProgram = new List<UserProgram>();
		public int ExerciseCount { get; set; }
	}
}
