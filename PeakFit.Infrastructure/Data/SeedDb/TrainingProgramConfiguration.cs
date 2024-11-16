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
                .HasDefaultValue("https://w7.pngwing.com/pngs/83/516/png-transparent-workout-dumbbells-weightlifting-dumbell-gym-thumbnail.png");
            var data = new SeedData();
            builder.HasData(new TrainingProgram[] { data.Program1 });
        }
    }
}
