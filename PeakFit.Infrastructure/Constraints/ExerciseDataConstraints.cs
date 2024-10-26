using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Infrastructure.Constraints
{
    public static class ExerciseDataConstraints
    {
        public const int ExerciseMinLength = 3;
        public const int ExerciseMaxLength = 50;

        public const int RepsMin = 1;
        public const int RepsMax = 50;
        
        public const int SetsMin = 1;
        public const int SetsMax = 10;

    }
}
