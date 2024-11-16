using PeakFit.Core.Models.ExerciseModels;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Models.TrainingProgramModels
{
    public class TrainingProgramDetailsModel
    {
        [Display(Name = "Program identifier")]
        public int Id { get; set; }

        [Display(Name = "Program title")]
        public string Title { get; set; } = null!;
        [Display(Name = "Program category identifier")]
        public int CategoryId { get; set; }
        [Display(Name = "Program category title")]
        public string CategoryName { get; set; } = null!;
        [Display(Name = "Program image")]
        public string ImageUrl { get; set; } = null!;
        [Display(Name = "Trainer identifier")]
        public string TrainerId { get; set; } = null!;
        [Display(Name = "Trainer identifier")]
        public string TrainerName { get; set; } = null!;
        [Display(Name = "Program rating")]
        public double Rating { get; set; }
        [Display(Name = "Program's exercises")]
        public ICollection<ProgramExerciseDetailsViewModel> Exercises { get; set; } = new List<ProgramExerciseDetailsViewModel>();


    }
}
