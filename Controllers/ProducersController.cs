using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStudio.Data;
using MovieStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStudio.Controllers
{
	public class ProducersController : Controller
	{
        private readonly AppDbContext _context;
        public ProducersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Producers.ToListAsync();
            return View(data);
        }

        //Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var data = _context.Producers.Find(id);
            return View(data);

        }
        [HttpPost]
        public IActionResult Edit(Producer producer)
        {
            var data = _context.Producers.FirstOrDefault(a => a.Id == producer.Id);
            if (ModelState.IsValid)
            {
                
                data.ProfilePictureURL = producer.ProfilePictureURL;
                data.Bio = producer.Bio;
                data.FullName = producer.FullName;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        //Delete
        public IActionResult Delete(int? id)
        {

            var data = _context.Producers.Find(id);
            _context.Producers.Remove(data);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }

        //Details
        public IActionResult Details(int? id)
        {
            var data = _context.Producers.Find(id);
            return View(data);

        }
    }
}
