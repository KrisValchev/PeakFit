using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Infrastructure.Data.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [Comment("First name of a user")]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [Comment("Last name of a user")]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;
        [Comment("User profile picture")]
        [DefaultValue("https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png")]
        public string ProfilePicture { get; set; } = string.Empty;
        [Required]
        [Comment("User's gender")]
        [PersonalData]
        public string Gender { get; set; } = string.Empty;
        [Comment("Inspirational description about the user")]
        public string AboutDescription { get; set; } = string.Empty;
    }
}
