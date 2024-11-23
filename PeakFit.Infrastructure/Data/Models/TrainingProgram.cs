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
       
        public string? ImageUrl { get; set; }
        [Required]
        [Comment("Trainer identifier")]
        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
        [Required]
        [Comment("Tells if program is deleted")]
        public bool IsDeleted { get; set; }

		public IList<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<ProgramExercise> Exercises { get; set; } = new List<ProgramExercise>();
		public ICollection<UserProgram> UsersPrograms { get; set; } = new List<UserProgram>();
	}
}
