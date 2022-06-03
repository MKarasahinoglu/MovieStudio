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


    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;
        public ActorsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Actors.ToListAsync();
            return View(data);
        }

        //Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var data = _context.Actors.Find(id);
            return View(data);
            
        }
        [HttpPost]
        public IActionResult Edit(Actor actor)
        {
            var data = _context.Actors.FirstOrDefault(a => a.Id == actor.Id);
            if (ModelState.IsValid)
            {
                
                data.ProfilePictureURL = actor.ProfilePictureURL;
                data.Bio = actor.Bio;
                data.FullName = actor.FullName;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        
        
        //Delete
        public IActionResult Delete(int? id)
        {

            var data = _context.Actors.Find(id);
            _context.Actors.Remove(data);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }

        //Details
        public IActionResult Details(int? id)
        {
            var data = _context.Actors.Find(id);
            return View(data);

        }
       




    }
}
