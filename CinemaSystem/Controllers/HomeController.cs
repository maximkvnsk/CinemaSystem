using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CinemaSystem.Models;
using CinemaSystem.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaSystem.Controllers
{
    public class HomeController : Controller
    {

        private CinemaDBContext db;
        public HomeController(CinemaDBContext context)
        {
            db = context;
        }

        [Authorize(Roles = "Director, Customer")]
        public async Task<IActionResult> Index()
        {

            return View(await db.Movies.Include(r => r.MovieRatingNavigation).ToListAsync());
        }

        [Authorize(Roles = "Director")]
        public async Task<IActionResult> Create()
        {
            var vm = new RatingModel();
            vm.MovieRatings = db.MovieRatings
                                  .Select(a => new SelectListItem()
                                  {
                                      Value = a.RatingId.ToString(),
                                      Text = a.RatingValue
                                  })
                                  .ToList();
            ViewBag.vm = vm.MovieRatings;
            return  View();
        }

        [HttpPost]
        [Authorize(Roles = "Director")]
        public async Task<IActionResult> Create(Movie movie)
        {

            db.Movies.Add(movie);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Director")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Movie movie = await db.Movies.FirstOrDefaultAsync(p => p.MovieId == id);
                if (movie != null)
                {
                    var vm = new RatingModel();
                    vm.MovieRatings = db.MovieRatings
                                          .Select(a => new SelectListItem()
                                          {
                                              Value = a.RatingId.ToString(),
                                              Text = a.RatingValue
                                          })
                                          .ToList();
                    ViewBag.vm = vm.MovieRatings;
                    return View(movie);
                }
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "Director")]
        public async Task<IActionResult> Edit(Movie movie)
        {
            db.Movies.Update(movie);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        [Authorize(Roles = "Director")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Movie movie = await db.Movies.FirstOrDefaultAsync(p => p.MovieId == id);
                if (movie != null)
                    return View(movie);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Director")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Movie movie = await db.Movies.FirstOrDefaultAsync(p => p.MovieId == id);
                if (movie != null)
                {
                    db.Movies.Remove(movie);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}
