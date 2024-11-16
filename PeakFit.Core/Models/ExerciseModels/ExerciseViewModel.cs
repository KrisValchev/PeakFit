using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Models.ExerciseModels
{
    public class ExerciseViewModel
    {
        [Comment("Exercise identifier")]
        public int Id { get; set; }
        [Display(Name = "Category Identifier")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Exercise Name")]
        public string ExerciseName { get; set; } = null!;   
    }
}
