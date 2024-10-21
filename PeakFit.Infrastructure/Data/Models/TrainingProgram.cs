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
        
        //Trainer Property

        //Think about the logic associated with the trainer and client tables (should it be only one or two separated)
    }
}
