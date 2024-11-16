using PeakFit.Core.Models.CategoryModels;
using PeakFit.Core.Models.ExerciseModels;
using PeakFit.Core.Models.ProgramExerciseModels;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PeakFit.Infrastructure.Constraints.Errors;

namespace PeakFit.Core.Models.TrainingProgramModels
{
    public class AddTrainingProgramModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Program category")]
        public int CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
        [Display(Name = "Program image")]
        public string? ImageUrl { get; set; }
        public IEnumerable<ProgramExerciseAddModel> ProgramExercises { get; set; } = new List<ProgramExerciseAddModel>();
        

    }
}
