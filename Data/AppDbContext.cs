using Microsoft.EntityFrameworkCore;
using MovieStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStudio.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
		{

		}
		
		public DbSet<Actor> Actors { get; set; }
		public DbSet<Movie> Movies { get; set; }
		
		
		public DbSet<Producer> Producers { get; set; }
	}
}
