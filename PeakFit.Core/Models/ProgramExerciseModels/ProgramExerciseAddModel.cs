using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Models.ProgramExerciseModels
{
    public class ProgramExerciseAddModel
    {
        [Comment("This Exercise Identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("The Exercise identifier ")]
        public int ExerciseId { get; set; }
        [Required]
        [Comment("The Exercise number of sets")]
        public int Sets { get; set; }
        [Required]
        [Comment("The Exercise number of reps")]
        public int Reps { get; set; }
    }
}
