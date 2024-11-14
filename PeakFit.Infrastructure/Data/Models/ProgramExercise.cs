using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PeakFit.Infrastructure.Constraints.ExerciseDataConstraints;

namespace PeakFit.Infrastructure.Data.Models
{
    public class ProgramExercise
    {
        [Comment("ProgramExercise identifier")]
        public int Id { get; set; }
       
        [Required]
        [Comment("Repetition count of exercise")]
        [Range(RepsMin, RepsMax)]
        public int Reps { get; set; }
        [Required]
        [Comment("Sets count of exercise")]
        [Range(SetsMin, SetsMax)]
        public int Sets { get; set; }
        [Required]
        [Comment("Program identifier")]
        public int ProgramId { get; set; }
        [ForeignKey("ProgramId")]
        public TrainingProgram Program { get; set; } = null!;
        [Required]
        [Comment("Exercise identifier")]
        public int ExerciseId { get; set; }
        [ForeignKey("ExerciseId")]
        public Exercise Exercise { get; set; } = null!;


    }
}
