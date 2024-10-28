
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PeakFit.Infrastructure.Data.Models;

namespace PeakFit.Web.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserProgram>().HasKey(pc => new { pc.UserId, pc.ProgramId });
            base.OnModelCreating(builder);
            builder.Entity<UserEvent>().HasKey(pc => new { pc.UserId, pc.EventId });
            base.OnModelCreating(builder);

        }
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Exercise> Exercises { get; set; } = null!;
        public DbSet<TrainingProgram> TrainingPrograms { get; set; } = null!;
        public DbSet<UserEvent> UsersEvents { get; set; } = null!;
        public DbSet<UserProgram> UsersPrograms { get; set; } = null!;



    }
}
