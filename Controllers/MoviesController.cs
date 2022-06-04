using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieStudio.Data;
using MovieStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStudio.Controllers
{
	public class MoviesController : Controller
	{
        private readonly AppDbContext _context;
        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Movies.Include(p => p.Producer).ToListAsync();
           
            return View(data);
        }

        //Create
        [HttpGet]
        public IActionResult Create(int? id)
        {
            var data = _context.Movies.Find(id);
            ViewBag.ProducerSelectList=new SelectList(_context.Producers,"Id","FullName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,ImageURL,MovieCategory,ProducerId,Description")] Movie movie)
        {
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "FullName", movie.ProducerId);
            if (ModelState.IsValid)
            {
                _context.Add(movie);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View();
        }

        //Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {

            var data = _context.Movies.Find(id);
            ViewBag.ProducerSelectList = new SelectList(_context.Producers, "Id", "FullName");
            return View(data);
            //var data = _context.Movies.Include(p => p.Producer).Include(a => a.Actor_Movies).Where(i => i.Id == id).FirstOrDefault(i => i.Id == id);
            //return View(data);

        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            var data = _context.Movies.Include(p => p.Producer).Include(a => a.Actor_Movies).Where(i => i.Id == movie.Id).FirstOrDefault(i => i.Id == movie.Id);
            if (ModelState.IsValid)
            {

                data.ImageURL = movie.ImageURL;
                data.MovieCategory = movie.MovieCategory;
                data.Name = movie.Name;
                
                data.ProducerId = movie.ProducerId;
                data.Description = movie.Description;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        //Delete
        public IActionResult Delete(int? id)
        {

            var data = _context.Movies.Find(id);
            _context.Movies.Remove(data);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }

        //Details
        public IActionResult Details(int? id)
        {
            var data = _context.Movies.Include(p => p.Producer).Include(a => a.Actor_Movies).Where(i => i.Id == id).FirstOrDefault(i => i.Id == id);
           
            return View(data);

        }


        public async Task<IActionResult> Filter(string searchString,Movie movie)
        {
            var allMovies = await _context.Movies.Include(p => p.Producer).ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                

                var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allMovies);
        }

    }
}
