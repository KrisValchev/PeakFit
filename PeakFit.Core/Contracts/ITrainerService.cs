using PeakFit.Core.Models.TrainerModels;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Contracts
{
	public interface ITrainerService
	{
		Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);
		Task AddPhoneNumberAsync(string id,BecomeTrainerModel model);
        Task<bool> IsInTrainerRoleAsync(string userId);

    }
}
