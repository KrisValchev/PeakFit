using System.ComponentModel.DataAnnotations;

namespace PeakFit.Core.Models.ApplicationUserModels
{
    public class AllUsersSerivceModel
    {
        [Display(Name = "User Id")]
        public string Id { get; set; } = null!;

        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
        [Display(Name = "Is Trainer")]
		public bool IsTrainer { get; set; }
        public string PhoneNumber { get; set; } = null!;
	}
}
