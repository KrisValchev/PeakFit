using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
using PeakFit.Core.Contracts;
using PeakFit.Core.Enumerations;
using PeakFit.Core.Models.ApplicationUserModels;
using PeakFit.Infrastructure.Common;
using PeakFit.Infrastructure.Data.Models;
using static PeakFit.Core.Constants.RoleConstants;
using System.Security.Claims;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace PeakFit.Core.Services
{
	public class ApplicationUserService(IRepository repository, UserManager<ApplicationUser> userManager) : IApplicationUserService
	{

		public async Task<UserQueryServiceModel> AllUsersAsync(string? id = null, string? firstName = null, string? lastName = null, UserSorting sorting = UserSorting.EmailDescending, int currentPage = 1, int usersPerPage = 1)
		{
			var users = repository.AllReadOnly<ApplicationUser>();

			if (id != null)
			{
				users = users
				   .Where(u => u.Id == id);
			}

			if (firstName != null)
			{
				users = users
				   .Where(u => u.FirstName == firstName);
			}

			if (lastName != null)
			{
				users = users
				   .Where(u => u.LastName == lastName);
			}

			users = sorting switch
			{
				UserSorting.EmailAscending => users
					.OrderBy(u => u.Email),
				UserSorting.EmailDescending => users
				.OrderByDescending(u => u.Email),
				UserSorting.FirstNameAscending => users
					.OrderBy(u => u.FirstName),
				UserSorting.FirstNameDescending => users
				.OrderByDescending(u => u.FirstName),
				UserSorting.LastNameAscending => users
				.OrderBy(u => u.LastName),
				UserSorting.LastNameDescending => users
				.OrderByDescending(u => u.LastName)
			};

			var AllUsers = await users
				.Skip((currentPage - 1) * usersPerPage)
				.Take(usersPerPage)
				.Select(e => new AllUsersSerivceModel()
				{
					Id = e.Id,
					Email = e.Email,
					FirstName = e.FirstName,
					LastName = e.LastName,
					IsTrainer = e.PhoneNumber != null,
					PhoneNumber=e.PhoneNumber
				})
				.ToListAsync();

			int usersCount = await users.CountAsync();

			return new UserQueryServiceModel()
			{
				TotalUsersCount = usersCount,
				Users = AllUsers,
			};
		}

		public async Task DeleteAsync(string userId)
		{
			var user = repository.All<ApplicationUser>().FirstOrDefault(u => u.Id == userId);

			if (user != null)
			{

				if (await userManager.IsInRoleAsync(user, TrainerRole))
				{
					var trainerEvents = await repository.AllReadOnly<Event>()
				.Where(r => r.UserId == userId)
				.ToListAsync();

					foreach (var item in trainerEvents)
					{
						var commentsToRemove = await repository.AllReadOnly<Comment>()
						.Where(c => c.UserId == userId || c.EventId == item.Id)
						.ToListAsync();
						foreach (var comment in commentsToRemove)
						{
							await repository.DeleteAsync<Comment>(comment.Id);
						}
						await repository.DeleteAsync<Event>(item.Id);
					}


					var trainerPrograms = await repository.AllReadOnly<TrainingProgram>()
				.Where(r => r.UserId == userId)
				.ToListAsync();
					foreach (var item in trainerPrograms)
					{
						var programs = await repository.AllReadOnly<ProgramExercise>()
				.Where(p => p.ProgramId == item.Id)
				.ToListAsync();

						foreach (var programExercise in programs)
						{
							await repository.DeleteAsync<ProgramExercise>(programExercise.Id);
						}
						var usersPrograms = await repository.AllReadOnly<UserProgram>()
				.Where(p => p.ProgramId == item.Id)
				.ToListAsync();

						foreach (var userProgram in usersPrograms)
						{
							UserProgram userProgramToRemove = new UserProgram()
							{
								ProgramId = userProgram.ProgramId,
								UserId = userProgram.UserId
							};
							await repository.RemoveAsync(userProgramToRemove);
						}

						var ratings = await repository.AllReadOnly<Rating>()
							.Where(r => r.TrainingProgramId == item.Id)
							.ToListAsync();
						foreach (var rating in ratings)
						{
							await repository.DeleteAsync<Rating>(rating.Id);
						}
						await repository.DeleteAsync<TrainingProgram>(item.Id);
					}
					await repository.DeleteAsync<ApplicationUser>(userId);
					await repository.SaveChangesAsync();
				}
				else
				{
					var usersPrograms = await repository.AllReadOnly<UserProgram>()
				.Where(p => p.UserId == userId)
				.ToListAsync();
					foreach (var userProgram in usersPrograms)
					{
						UserProgram userProgramToRemove = new UserProgram()
						{
							ProgramId = userProgram.ProgramId,
							UserId = userProgram.UserId
						};
						await repository.RemoveAsync(userProgramToRemove);
					}

					var ratings = await repository.AllReadOnly<Rating>()
							.Where(r => r.UserId == userId)
							.ToListAsync();
					foreach (var rating in ratings)
					{
						await repository.DeleteAsync<Rating>(rating.Id);
					}

					await repository.DeleteAsync<ApplicationUser>(userId);
					await repository.SaveChangesAsync();
				}

			}


		}
		
		public async Task DemoteUserAsync(string id)
		{
			var user = repository.All<ApplicationUser>().FirstOrDefault(u => u.Id == id);

			if (user != null)
			{
				if (await userManager.IsInRoleAsync(user, TrainerRole))
				{
					await userManager.RemoveFromRoleAsync(user, TrainerRole);
				}
				if (await userManager.IsInRoleAsync(user, AdminRole))
				{
					await userManager.RemoveFromRoleAsync(user, AdminRole);
				}
				user.PhoneNumber = null;
				var trainerEvents = await repository.AllReadOnly<Event>()
			.Where(r => r.UserId == user.Id)
			.ToListAsync();

				foreach (var item in trainerEvents)
				{
					var commentsToRemove = await repository.AllReadOnly<Comment>()
					.Where(c => c.UserId == user.Id || c.EventId == item.Id)
					.ToListAsync();
					foreach (var comment in commentsToRemove)
					{
						await repository.DeleteAsync<Comment>(comment.Id);
					}
					await repository.DeleteAsync<Event>(item.Id);
				}


				var trainerPrograms = await repository.AllReadOnly<TrainingProgram>()
			.Where(r => r.UserId == user.Id)
			.ToListAsync();
				foreach (var item in trainerPrograms)
				{
					var programs = await repository.AllReadOnly<ProgramExercise>()
			.Where(p => p.ProgramId == item.Id)
			.ToListAsync();

					foreach (var programExercise in programs)
					{
						await repository.DeleteAsync<ProgramExercise>(programExercise.Id);
					}
					var usersPrograms = await repository.AllReadOnly<UserProgram>()
			.Where(p => p.ProgramId == item.Id)
			.ToListAsync();

					foreach (var userProgram in usersPrograms)
					{
						UserProgram userProgramToRemove = new UserProgram()
						{
							ProgramId = userProgram.ProgramId,
							UserId = userProgram.UserId
						};
						await repository.RemoveAsync(userProgramToRemove);
					}

					var ratings = await repository.AllReadOnly<Rating>()
						.Where(r => r.TrainingProgramId == item.Id)
						.ToListAsync();
					foreach (var rating in ratings)
					{
						await repository.DeleteAsync<Rating>(rating.Id);
					}
					await repository.DeleteAsync<TrainingProgram>(item.Id);
				}
				await repository.SaveChangesAsync();
				await userManager.AddToRoleAsync(user, UserRole);
			}
		}

		public async Task<bool> ExistsAsync(string id)
		{
			return await repository.AllReadOnly<ApplicationUser>()
			   .AnyAsync(r => r.Id == id);
		}

		public async Task<bool> IsAdminAsync(string id)
		{
			var user = repository.All<ApplicationUser>().FirstOrDefault(u => u.Id == id);

			if (user != null)
			{
				return await userManager.IsInRoleAsync(user, AdminRole);
			}

			return false;
		}
		public async Task<bool> IsTrainerAsync(string id)
		{
			var user = repository.All<ApplicationUser>().FirstOrDefault(u => u.Id == id);

			if (user != null)
			{
				return await userManager.IsInRoleAsync(user, TrainerRole);
			}

			return false;
		}
		public async Task<bool> IsUserAsync(string id)
		{
			var user = repository.All<ApplicationUser>().FirstOrDefault(u => u.Id == id);

			if (user != null)
			{
				return await userManager.IsInRoleAsync(user, UserRole);
			}

			return false;
		}

		public async Task PromoteFromUserToAdminAsync(string id,string phoneNumber)
		{
			var user = repository.All<ApplicationUser>().FirstOrDefault(u => u.Id == id);

			if (user != null)
			{
				user.PhoneNumber=phoneNumber;
				await userManager.AddToRoleAsync(user, AdminRole);
				await userManager.AddToRoleAsync(user, TrainerRole);
				if(await userManager.IsInRoleAsync(user, UserRole))
				{
				await userManager.RemoveFromRoleAsync(user, UserRole);
				}
				await repository.SaveChangesAsync();
			}
		}
		public async Task PromoteFromTrainerToAdminAsync(string id)
		{
			var user = repository.All<ApplicationUser>().FirstOrDefault(u => u.Id == id);

			if (user != null)
			{
				await userManager.AddToRoleAsync(user, AdminRole);
				
			}
		}
		public async Task<UsersDetailsServiceModel> UserDetailsAsync(string id)
		{
			return await repository.AllReadOnly<ApplicationUser>()
				.Where(r => r.Id == id)
				.Select(r => new UsersDetailsServiceModel()
				{
					Id = id,
					Email = r.Email,
					UserName = r.UserName,
					FirstName = r.FirstName,
					LastName = r.LastName
				})
				.FirstAsync();
		}

		public async Task<bool> PhoneNumberExistsAsync(string phoneNumber)
		{
			return await repository.AllReadOnly<ApplicationUser>().AnyAsync(u => u.PhoneNumber == phoneNumber);
		}
	}
}
