using Microsoft.EntityFrameworkCore;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.AdminModels;
using PeakFit.Infrastructure.Common;
using PeakFit.Infrastructure.Data.Models;
using static PeakFit.Infrastructure.Constraints.EventDataConstraints;
using static PeakFit.Core.Constants.RoleConstants;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace PeakFit.Core.Services
{
    public class AdminService(IRepository repository, UserManager<ApplicationUser> userManager) : IAdminService
    {
	

		public async Task<AdminPanelServiceModel> PanelInformationAsync()
        {
            int trainerCount= 0;
            int userCount= 0;
            foreach (var user in await repository.All<ApplicationUser>().ToListAsync())
            {
                if(await userManager.IsInRoleAsync(user, UserRole))
                {
                    userCount++;
                }
                else
                {
                    trainerCount++;
                }
            }

            var eventCount = await repository.All<Event>().Where(e => e.IsDeleted == false).CountAsync();
            var programsCount = await repository.All<TrainingProgram>().Where(tp => tp.IsDeleted == false).CountAsync();



		var panelInformation = new AdminPanelServiceModel
            {
                TotalUsers = userCount,
                TotalTrainers = trainerCount,
                TotalPrograms = programsCount,
                TotalEvents = eventCount,
                LatestEvents = await repository.All<Event>().Where(e => e.IsDeleted == false)
                    .OrderByDescending(x => x)
                    .Take(15)
                    .Select(x => new AdminLatest15EventsServiceModel
                    {
                        TrainerFirstName = x.User.FirstName,
                        TrainerLastName = x.User.LastName,
                        EventTitle = x.Title,
                        StartDate = x.StartDate.ToString(StartDateTimeFormat),
                        StartHour = x.StartHour.ToString(StartHourTimeFormat),
                        CommentsCount = x.Comments.Where(c => c.IsDeleted == false).Count(),
                    })
                    .ToListAsync(),

                LatestPrograms = await repository.All<TrainingProgram>().Where(e => e.IsDeleted == false)
            .OrderByDescending(x => x)
            .Take(15)
            .Select(x => new AdminLatest15ProgramsServiceModel
            {
                TrainerFirstName = x.User.FirstName,
                TrainerLastName = x.User.LastName,
                TrainingProgramCategory = x.Category.CategoryName,
                ExercisesCount = x.Exercises.Count(),
                Rating= x.Ratings.Any() == true ? x.Ratings.Average(r => r.Value) : 0
            })
            .ToListAsync()
            };
            return panelInformation;
        }
    }
}
