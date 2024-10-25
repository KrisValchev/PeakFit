using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Infrastructure.Data.Models
{
    public class UserProgram
    {
        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = null!;
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!;
        [Required]
        [Comment("Which training program the user is subscriber to")]
        public int ProgramId { get; set; } 
        [ForeignKey("ProgramId")]
        public TrainingProgram Program { get; set; } = null!;
    }
}
