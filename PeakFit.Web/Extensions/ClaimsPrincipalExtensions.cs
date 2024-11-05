using System.Security.Claims;
using static PeakFit.Core.Constants.RoleConstants;

namespace PeakFit.Web.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        // Id method is used to get the user's Id from the ClaimsPrincipal object
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        // IsAdmin method is used to check if the user is an admin
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRole);
        }
        // IsAdmin method is used to check if the user is a trainer
        public static bool IsTrainer(this ClaimsPrincipal user)
        {
            return user.IsInRole(TrainerRole);
        }
        // IsAdmin method is used to check if the user is an user
        public static bool IsUser(this ClaimsPrincipal user)
        {
            return user.IsInRole(UserRole);
        }
    }
}
