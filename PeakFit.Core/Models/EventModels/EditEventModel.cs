using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PeakFit.Infrastructure.Constraints.EventDataConstraints;
using static PeakFit.Infrastructure.Constraints.Errors;

namespace PeakFit.Core.Models.EventModels
{
    public class EditEventModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage =RequiredErrorMessage)]
        [StringLength(TitleMaxLength,MinimumLength =TitleMinLength,ErrorMessage =LengthErrorMessage)]
        [Display(Name ="Event title")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Event description")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Event image")]
        public string ImageUrl { get; set; } = null!;
        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Event start date")]
        public string StartDate { get; set; } = null!;
        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Event start hour")]
        public string StartHour { get; set; } = null!;
        public string TrainerId { get; set; } = null!;
    }
}
