using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Infrastructure.Data.Models
{
    public class Event
    {
        [Comment("Event identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("Event's title")]
        public string Title { get; set; } = null!;
        [Required]
        [Comment("Event's description")]
        public string Description { get; set; } = null!;
        [Required]
        [Comment("Event's date of starting")]
        public DateTime StartDate { get; set; }
        [Required]
        [Comment("Event's hour of starting")]
        public DateTime StartHour { get; set; }
        [Required]
        [Comment("Trainer identifier who created the event")]
        public string TrainerId { get; set; } = null!;
        [ForeignKey(nameof(TrainerId))]
        public Trainer Trainer { get; set; } = null!;
        public ICollection<Comment> Comments { get; set; }=new List<Comment>();
        [Required]
        [Comment("Tells if event is deleted")]
        public bool IsDeleted { get; set; }
    }
}
