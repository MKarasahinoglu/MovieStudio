﻿using MovieStudio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStudio.Models
{
	public class Actor
	{
		[Key]
		public int Id { get; set; }
		[Display(Name ="Profile Picture")]
		public string ProfilePictureURL { get; set; }
		[Display(Name = "Name")]
		public string FullName { get; set; }
		[Display(Name = "Biography")]
		public string Bio { get; set; }
		
	}
}
