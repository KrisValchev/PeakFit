
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PeakFit.Infrastructure.Data.Models;
using PeakFit.Infrastructure.Data.SeedDb;

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
            //data seed 
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new TrainingProgramConfiguration());
            builder.ApplyConfiguration(new ExerciseConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());

            //many to many relations 
            builder.Entity<UserProgram>().HasKey(pc => new { pc.UserId, pc.ProgramId });
            base.OnModelCreating(builder);

        }
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Exercise> Exercises { get; set; } = null!;
        public DbSet<TrainingProgram> TrainingPrograms { get; set; } = null!;
        public DbSet<UserProgram> UsersPrograms { get; set; } = null!;



    }
}
