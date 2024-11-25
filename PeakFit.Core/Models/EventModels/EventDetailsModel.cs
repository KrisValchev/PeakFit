using PeakFit.Core.Models.CommentModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Models.EventModels
{
    public class EventDetailsModel
    {
        [Display(Name = "Event identifier")]
        public int Id { get; set; }

        [Display(Name = "Event title")]
        public string Title { get; set; } = null!;
        [Display(Name = "Event date of starting")]
        public string StartDate { get; set; } = null!;

        [Display(Name = "Event time of starting")]
        public string StartHour { get; set; } = null!;
        [Display(Name = "Event image")]
        public string ImageUrl { get; set; } = null!;
        [Display(Name = "Trainer identifier")]
        public string TrainerId { get; set; } = null!;
        [Display(Name = "Trainer identifier")]
        public string TrainerName { get; set; } = null!;
        [Display(Name ="Event description")]
        public string Description {  get; set; } = null!;
		[Display(Name = "Event trainer phone number")]
		public string PhoneNumber { get; set; } = null!;
        [Display(Name = "Recipe's comments")]
        public ICollection<CommentsInfoViewModel> Comments { get; set; } = new List<CommentsInfoViewModel>();
        public CommentAddViewModel AddComment { get; set; } = new CommentAddViewModel();
    }
}
