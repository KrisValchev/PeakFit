using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Models.AdminModels
{
    public class AdminLatest15ProgramsServiceModel
    {
        public string TrainerFirstName { get; set; } = null!;
        public string TrainerLastName { get; set; } = null!;
        public string TrainingProgramCategory { get; set; } = null!;
        public int ExercisesCount { get; set; } 
        public double Rating { get; set; }
    }
}
