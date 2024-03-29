﻿using MovieStudio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStudio.Models
{
	public class Movie
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		[Display(Name = "Image URL")]
		public string ImageURL { get; set; }
		
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		[Display(Name = "Genre")]
		public MovieCategory MovieCategory { get; set; }
		
		public int CinemaId { get; set; }
		[Display(Name = "Producer")]
		public int ProducerId { get; set; }
		public Producer Producer { get; set; }
	}
}
