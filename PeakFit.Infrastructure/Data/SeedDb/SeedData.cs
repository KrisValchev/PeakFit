using Microsoft.AspNetCore.Identity;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PeakFit.Core.Constants.RoleConstants;

namespace PeakFit.Infrastructure.Data.SeedDb
{
	internal class SeedData
	{
		public ApplicationUser Admin { get; set; }
		private void SeedUser()
		{
			var hasher = new PasswordHasher<ApplicationUser>();

			Admin = new ApplicationUser()
			{
				Id = "8acdd283-300d-4ef1-a83f-813efc164767",
				UserName = "admin@gmail.com",
				NormalizedUserName = "admin@gmail.com",
				Email = "admin@gmail.com",
				NormalizedEmail = "admin@gmail.com",
				FirstName = "Admin",
				LastName = "Admin",
				Gender = "Male",
				Role=AdminRole,
				ProfilePicture = "https://www.pngmart.com/files/21/Admin-Profile-Vector-PNG-Clipart.png"
			};

			Admin.PasswordHash =
			hasher.HashPassword(Admin, "Admin1234");
		}
	}
}
