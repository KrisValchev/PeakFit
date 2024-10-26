using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Infrastructure.Constraints
{
	public static class ApplicationUserDataConstraints
	{
		public const int FirstNameMinLength = 2;
		public const int FirstNameMaxLength = 30;	
		
		public const int LastNameMinLength = 2;
		public const int LastNameMaxLength = 30;

		public const int AboutDescriptionMinLength = 10;
		public const int AboutDescriptionMaxLength = 200;
	}
}
