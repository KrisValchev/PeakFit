using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Infrastructure.Data.Models
{
    public class Comment
    {
        [Comment("Comment identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("Comment's title")]
        public string Title { get; set; } = null!;
        [Required]
        [Comment("Comment's description")]
        public string Description { get; set; } = null!;
        [Required]
        [Comment("Comment's date of posting")]
        public DateTime PostedOn { get; set; }
        [Required]
        [Comment("User identifier who posted the comment ")]
        public string UserId { get; set; } =null!;
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
        [Required]
        [Comment("Event identifier which the comment is posted on")]
        public int EventId { get; set; }
        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; } = null!;
        [Required]
        [Comment("Tells if comment is deleted")]
        public bool IsDeleted { get; set; }

    }
}
