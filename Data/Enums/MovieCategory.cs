using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStudio.Data
{
	public enum MovieCategory
	{
		Action=1,
		Anime,
		Children,
		Classic,
		Comedy,
		Documentary,
		Drama,
		Fantasy,
		Horror,
		Musical,
		Romance,
		[Display(Name ="Sci-Fi")]
		Sci_Fi,
		Sport,
		Thriller,
		Cartoon
	}
}
