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
        [Key]
        [Comment("Exercise identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("Name of exercise")]
        public string ExerciseName { get; set; } = null!;
        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;
        public ICollection<ProgramExercise> Programs = new List<ProgramExercise>();
    }
}
