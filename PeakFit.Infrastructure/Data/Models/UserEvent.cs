using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace PeakFit.Infrastructure.Data.Models
{
    public class UserEvent
    {
        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = null!;
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!;
        [Required]
        [Comment("Which event the user is subscriber to")]
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public Event Event { get; set; } = null!;
    }
}
