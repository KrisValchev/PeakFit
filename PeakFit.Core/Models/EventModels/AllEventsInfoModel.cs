using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PeakFit.Core.Models.EventModels
{
    public class AllEventsInfoModel
    {
        [Display(Name ="Event identifier")]    
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
        [Display(Name = "Trainer username")]
        public string TrainerUserName { get; set; } = null!;

    }
}
