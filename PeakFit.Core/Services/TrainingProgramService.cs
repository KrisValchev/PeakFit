using Microsoft.EntityFrameworkCore;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.EventModels;
using PeakFit.Core.Models.TrainingProgramModels;
using PeakFit.Infrastructure.Common;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Services
{
    public class TrainingProgramService(IRepository repository) : ITrainingProgramService
    {
        public async Task<IEnumerable<AllTrainingProgramsInfoModel>> AllTrainingProgramsAsync()
        {
            var programs = repository.AllReadOnly<TrainingProgram>().Where(p => p.IsDeleted == false);

            var allPrograms = await programs.Select(p => new AllTrainingProgramsInfoModel()
            {
                Id = p.Id,
                TrainerId = p.UserId,
                TrainerUserName = $"{p.User.FirstName} {p.User.LastName}",
                ImageUrl = p.ImageUrl,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.CategoryName,
                Rating =  p.Ratings.Average()

            }).ToListAsync();
            return allPrograms;
        }
    }
}
