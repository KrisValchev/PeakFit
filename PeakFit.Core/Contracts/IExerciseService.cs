using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeakFit.Core.Models.ExerciseModels;

namespace PeakFit.Core.Contracts
{
    public interface IExerciseService
    {
        public Task<IEnumerable<Exercise>> GetExercisesByCategoryAsync(int categoryId);
    }
}
