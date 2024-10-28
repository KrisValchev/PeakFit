using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Infrastructure.Data.Models
{
    public class TrainingProgram
    {
        [Comment("Program identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
        [Comment("Program's banner")]
        [DefaultValue("https://w7.pngwing.com/pngs/83/516/png-transparent-workout-dumbbells-weightlifting-dumbell-gym-thumbnail.png")]
        public string? ImageUrl { get; set; } = null!;
        [Required]
        [Comment("Trainer identifier")]
        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
        [Required]
        [Comment("Tells if program is deleted")]

		public IList<double> Ratings { get; set; } = new List<double>();
		public bool IsDeleted { get; set; }
    }
}
