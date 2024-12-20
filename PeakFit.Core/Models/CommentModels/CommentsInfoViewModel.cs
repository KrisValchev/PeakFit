﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Core.Models.CommentModels
{
	public class CommentsInfoViewModel
	{
		public int Id { get; set; }

		[Display(Name = "Title")]
		public string Title { get; set; } = string.Empty;

		[Display(Name = "Description")]
		public string Description { get; set; } = string.Empty;

		[Display(Name = "Author first name")]
		public string AuthorFirstName { get; set; } = null!;

		[Display(Name = "Author last name")]
		public string AuthorLastName { get; set; } = null!;

		[Display(Name = "Author profile picture")]
		public string AuthorProfilePicture { get; set; } = null!;

		[Display(Name = "Posted Date")]
		public string PostedOn { get; set; } = null!;

		[Display(Name = "Recipe Id")]
		public int EventId { get; set; }

		[Display(Name = "Recipe Name")]
		public string EventName { get; set; } = null!;

		[Display(Name = "Author Id")]
		public string AuthorId { get; set; } = null!;
	}
}
