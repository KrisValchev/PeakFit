using PeakFit.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeakFit.Core.Models.ExerciseModels;
using PeakFit.Infrastructure.Common;
using PeakFit.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace PeakFit.Core.Services
{

    public class ExerciseService(IRepository repository) : IExerciseService
    {
        public async Task<IEnumerable<Exercise>> GetExercisesByCategoryAsync(int categoryId)
        {
            var exercises= await repository.AllReadOnly<Exercise>().Where(p => p.CategoryId == categoryId).Include(e=>e.Category)
                .ToListAsync();
            return exercises;
        }
    }
}
