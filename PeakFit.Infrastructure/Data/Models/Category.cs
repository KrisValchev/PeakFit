using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Infrastructure.Data.Models
{
    public class Category
    {
        [Comment("Category identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("Name of category")]
        public string CategoryName { get; set; } = null!;

        public ICollection<Exercise> Exercises { get; set;}=new List<Exercise>();
        public ICollection<TrainingProgram> Programs { get; set;}=new List<TrainingProgram>();

    }
}
