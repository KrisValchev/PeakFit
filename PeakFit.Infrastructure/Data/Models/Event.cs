using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using static PeakFit.Infrastructure.Constraints.EventDataConstraints;

namespace PeakFit.Infrastructure.Data.Models
{
    public class Event
    {
        [Comment("Event identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("Event's title")]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;
        [Comment("Event's banner")]
        [DefaultValue("https://www.hussle.com/blog/wp-content/uploads/2020/12/Gym-structure-1080x675.png")]
        public string? ImageUrl { get; set; } = null!;
        [Required]
        [Comment("Event's description")]
        [MaxLength(DescriptionMaxLength)]
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
