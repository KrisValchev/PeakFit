using Microsoft.EntityFrameworkCore;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PeakFit.Infrastructure.Constraints.CategoryDataConstraints;

namespace PeakFit.Core.Models.CategoryModels
{
    public class CategoryViewModel
    {
        [Key]
        [Comment("This Category Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("The Category Name")]
        public string CategoryName { get; set; } = null!;

        [Comment("All Programs that are in this Category")]
        public ICollection<TrainingProgram> Programs = new List<TrainingProgram>();
        [Comment("All Exercises that are in this Category")]
        public ICollection<ProgramExercise> Exercises = new List<ProgramExercise>();
    }
}
