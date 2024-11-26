using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PeakFit.Infrastructure.Constraints.Errors;
using static PeakFit.Infrastructure.Constraints.EventDataConstraints;

namespace PeakFit.Core.Models.EventModels
{
	public class EventServiceModel
	{
		[Display(Name = "Event identifier")]
		public int Id { get; set; }

		[Display(Name = "Event title")]
		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = LengthErrorMessage)]
		public string Title { get; set; } = null!;
		[Display(Name = "Event date of starting")]
		[Required(ErrorMessage = RequiredErrorMessage)]
		public string StartDate { get; set; } = null!;

		[Display(Name = "Event time of starting")]
		[Required(ErrorMessage = RequiredErrorMessage)]
		public string StartHour { get; set; } = null!;
		[Required(ErrorMessage = RequiredErrorMessage)]
		[Display(Name = "Event image")]
		public string ImageUrl { get; set; } = null!;
		[Display(Name = "Trainer identifier")]
		public string TrainerId { get; set; } = null!;
		[Display(Name = "Trainer username")]
		public string TrainerUserName { get; set; } = null!;
		[Display(Name = "Trainer email")]
		public string TrainerEmail { get; set; } = null!;
	}
}
