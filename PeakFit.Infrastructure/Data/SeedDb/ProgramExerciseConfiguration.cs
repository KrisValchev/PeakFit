using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Infrastructure.Data.SeedDb
{
    internal class ProgramExerciseConfiguration : IEntityTypeConfiguration<ProgramExercise>
    {
        public void Configure(EntityTypeBuilder<ProgramExercise> builder)
        {
            var data = new SeedData();
            builder.HasData(new ProgramExercise[] { data.HackSquatProgram,data.DeadliftProgram,data.BulgarianSplitSquatProgram,data.LegPressProgram});
        }
    }
}
