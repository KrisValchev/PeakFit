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
    public class Exercise
    {
        [Comment("Exercise identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("Name of exercise")]
        public string ExerciseName { get; set; } = null!;
        [Required]
        [Comment("Repetition count of exercise")]
        public int Reps { get; set; }
        [Required]
        [Comment("Sets count of exercise")]
        public int Sets { get; set; }
        [Required]
        [Comment("Program identifier")]
        public int ProgramId { get; set; }
        [ForeignKey("ProgramId")]
        public TrainingProgram Program { get; set; } = null!;
        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;

    }
}
