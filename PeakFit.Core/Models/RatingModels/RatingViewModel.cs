using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Models.RatingModels
{
	public class RatingViewModel
	{
		[Required]
		[Comment("This Rating value")]
		public int Value { get; set; }
		[Required]
		[Comment("The user who rated the program")]
		public string UserId { get; set; } = null!;
		[Required]
		[Comment("The program that is rated")]
		public int TrainingProgramId { get; set; }
	}
}
