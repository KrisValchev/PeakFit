using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PeakFit.Infrastructure.Constraints.ExerciseDataConstraints;

namespace PeakFit.Core.Models.ExerciseModels
{
    public class ProgramExerciseDetailsViewModel
    {
        [Comment("This Exercise Identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("The Exercise name ")]
        public string ExerciseName { get; set; } = null!;
        [Required]
        [Comment("The Exercise number of sets")]
        public int Sets { get; set; } 
        [Required]
        [Comment("The Exercise number of reps")]
        public int Reps { get; set; }


    }
}
