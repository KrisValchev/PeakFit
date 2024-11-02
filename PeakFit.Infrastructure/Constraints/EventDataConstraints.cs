using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Infrastructure.Constraints
{
    public static class EventDataConstraints
    {
        public const int TitleMinLength = 4;
        public const int TitleMaxLength = 50;

        public const string StartDateTimeFormat = "dd-MM-yyyy";
        public const string StartHourTimeFormat = "HH:mm";

        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 1000;
    }
}
