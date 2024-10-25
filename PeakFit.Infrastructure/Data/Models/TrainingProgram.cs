using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        [Required]
        [Comment("Trainer identifier")]
        public string TrainerId { get; set; } = null!;
        [ForeignKey(nameof(TrainerId))]
        public Trainer Trainer { get; set; } = null!;
        [Required]
        [Comment("Tells if program is deleted")]
        public bool IsDeleted { get; set; }
    }
}
