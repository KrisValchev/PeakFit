
using System.ComponentModel.DataAnnotations;
using static PeakFit.Infrastructure.Constraints.Errors;
using static PeakFit.Infrastructure.Constraints.ApplicationUserDataConstraints;

namespace PeakFit.Core.Models.ApplicationUserModels
{
    public class UsersPromoteServiceModel
    {
        [Display(Name = "User Id")]
        public string Id { get; set; } = null!;
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Phone number")]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
    }
}
