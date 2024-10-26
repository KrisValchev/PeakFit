using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using static PeakFit.Infrastructure.Constraints.CategoryDataConstraints;


namespace PeakFit.Infrastructure.Data.Models
{
    public class Category
    {
        [Comment("Category identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("Name of category")]
        [MaxLength(CategoryNameMaxLength)]
        public string CategoryName { get; set; } = null!;

        public ICollection<Exercise> Exercises { get; set;}=new List<Exercise>();
        public ICollection<TrainingProgram> Programs { get; set;}=new List<TrainingProgram>();

    }
}
