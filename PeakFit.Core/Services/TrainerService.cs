using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeakFit.Core.Contracts;
using PeakFit.Core.Models.TrainerModels;
using PeakFit.Infrastructure.Common;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static PeakFit.Core.Constants.RoleConstants;
namespace PeakFit.Core.Services
{
    public class TrainerService(IRepository repository, UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager) : ITrainerService
    {
      //Add phone number to user
        public async Task AddPhoneNumberAsync(string id, BecomeTrainerModel model)
        {
            var trainer = await repository.GetByIdAsync<ApplicationUser>(id);

            trainer.PhoneNumber = model.PhoneNumber;
            var trainerRole = _roleManager.FindByNameAsync(TrainerRole).Result;

            if (await _userManager.IsInRoleAsync(trainer, UserRole) && trainerRole != null)
            {
            await _userManager.RemoveFromRoleAsync(trainer, UserRole);
                await _userManager.AddToRoleAsync(trainer, TrainerRole);
            }

            repository.SaveChangesAsync();
        }
       //Check if user is in trainer role
        public async Task<bool> IsInTrainerRoleAsync(string userId)
        {
            var trainer = await repository.AllReadOnly<ApplicationUser>().Where(t=>t.Id==userId).FirstOrDefaultAsync();
            return await _userManager.IsInRoleAsync(trainer,TrainerRole);

        }
        //Remove liked programs
		public async Task RemoveLikedPrograms(string userId)
		{
			var userPrograms = repository.All<UserProgram>().Where(t => t.UserId == userId).ToList();
            if(userPrograms.Any())
            {
                foreach (var userProgram in userPrograms)
                {
                    await repository.RemoveAsync(userProgram);
                    await repository.SaveChangesAsync();
                }
			}

		}
        //Check if user with phone number exists
		public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
            return await repository.AllReadOnly<ApplicationUser>()
               .AnyAsync(t => t.PhoneNumber == phoneNumber);
        }
    }
}
