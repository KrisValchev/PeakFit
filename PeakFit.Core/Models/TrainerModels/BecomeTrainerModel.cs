
using System.ComponentModel.DataAnnotations;
using static PeakFit.Infrastructure.Constraints.ApplicationUserDataConstraints;
using static PeakFit.Infrastructure.Constraints.Errors;

namespace PeakFit.Core.Models.TrainerModels
{
	public class BecomeTrainerModel
	{

		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = LengthErrorMessage)]
		[Display(Name = "Phone number")]
		[Phone]
		public string PhoneNumber { get; set; } = null!;
	}
}
