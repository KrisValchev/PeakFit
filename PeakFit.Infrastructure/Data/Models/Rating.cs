using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PeakFit.Infrastructure.Constraints.RatingDataConstraints;

namespace PeakFit.Infrastructure.Data.Models
{
    public class Rating
    {
        public int Id { get; set; }
        [Required]
        [Range(MinRatingValue, MaxRatingValue)]
        public int Value { get; set; }
        [Required]
        [Comment("The user who rated the training program")]
        public string UserId { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
        [Required]
        [Comment("The training program that is rated")]
        public int TrainingProgramId { get; set; }
        [ForeignKey(nameof(TrainingProgramId))]
        public TrainingProgram TrainingProgram { get; set; }
    }
}
