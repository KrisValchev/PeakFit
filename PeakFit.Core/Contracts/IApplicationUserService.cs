using PeakFit.Core.Enumerations;
using PeakFit.Core.Models.ApplicationUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Contracts
{
    public interface IApplicationUserService
    {
        Task<UserQueryServiceModel> AllUsersAsync(
           string? id = null,
           string? firstName = null,
           string? lastName = null,
           UserSorting sorting = UserSorting.EmailDescending,
           int currentPage = 1,
           int usersPerPage = 1);

        Task<UsersDetailsServiceModel> UserDetailsAsync(string id);

        Task PromoteUserAsync(string id,string phoneNumber);

        Task DemoteUserAsync(string id);

        Task DeleteAsync(string userId);

        Task<bool> ExistsAsync(string id);

        Task<bool> IsAdminAsync(string id);
        Task<bool> IsTrainerAsync(string id);
        Task<bool> PhoneNumberExistsAsync(string phoneNumber);

	}
}
