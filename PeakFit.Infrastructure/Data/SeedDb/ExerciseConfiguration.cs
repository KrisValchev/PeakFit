using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.SqlServer.Server;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Infrastructure.Data.SeedDb
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            var data = new SeedData();
            builder.HasData(new Exercise[] {
                data.HackSquat,
                data.Deadlift,
                data.BulgarianSplitSquat,
                data.LegPress,
                data.CalfRaise,
                data.Squat,
                data.Lunge,
                data.ArnoldPress,
                data.BarbellRow,
                data.BenchPress,
                data.BicepCurl,
                data.CableCrossover,
                data.ChestFly,
                data.CloseGripBenchPress,
                data.ConcentrationCurl,
                data.Crunch,
                data.DumbbellPullover,
                data.FacePull,
                data.FrontRaise,
                data.HammerCurl,
                data.InclineBenchPress,
                data.LateralRaise,
                data.LatPulldown,
                data.LegRaises,
                data.MountainClimbers,
                data.OverheadPress,
                data.OverheadTricepExtension,
                data.Plank,
                data.PullUp,
                data.PushUp,
                data.RussianTwist,
                data.SeatedCableRow,
                data.SidePlank,
                data.TBarRow,
                data.TricepDip,
                data.UprightRow
            });
        }
    }
}
