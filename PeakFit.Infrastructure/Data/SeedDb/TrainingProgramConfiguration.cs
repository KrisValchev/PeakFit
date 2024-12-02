using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Infrastructure.Data.SeedDb
{
    internal class TrainingProgramConfiguration : IEntityTypeConfiguration<TrainingProgram>
    {
        public void Configure(EntityTypeBuilder<TrainingProgram> builder)
        {
            builder.Property(tp => tp.ImageUrl)
                .HasDefaultValue("https://media.self.com/photos/6398b36c72eb56f726777d06/master/pass/weekly-workout-schedule.jpeg");
            var data = new SeedData();
            builder.HasData(new TrainingProgram[] { data.Program1 });
        }
    }
}
