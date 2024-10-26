using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Infrastructure.Constraints
{
    public static class CommentDataConstraints
    {
        public const int TitleMinLength = 4;
        public const int TitleMaxLength = 50;

        public const string PostedOnDateTimeFormat = "dd-MM-yyyy";

        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 200;
    }
}
