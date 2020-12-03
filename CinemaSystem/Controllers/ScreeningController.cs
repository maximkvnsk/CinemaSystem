using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using CinemaSystem.Models;
using CinemaSystem.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaSystem.Controllers
{
    public class ScreeningController: Controller { 

        private CinemaDBContext db;
        public ScreeningController(CinemaDBContext context)
        {
            db = context;
        }

        [Authorize(Roles = "Director, Customer")]
        public async Task<IActionResult> ScreeningMain()
        {

            return View(await db.Screenings.Include(r => r.Audithorium).Include(r1=>r1.Movie).ToListAsync());
        }

        [Authorize(Roles = "Director, Customer")]
        public async Task<IActionResult> Create()
        {
            var vm = new ScreeningModel();
            vm.Movies = db.Movies
                                  .Select(a => new SelectListItem()
                                  {
                                      Value = a.MovieId.ToString(),
                                      Text = a.Title
                                  })
                                  .ToList();
            vm.Audithoriums = db.Audithoria
                      .Select(a => new SelectListItem()
                      {
                          Value = a.AudithoriumId.ToString(),
                          Text = a.Name
                      })
                      .ToList();
            ViewBag.vm = vm.Movies;
            ViewBag.vm1 = vm.Audithoriums;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Director, Customer")]
        public async Task<IActionResult> Create(Screening screening)
        {

            db.Screenings.Add(screening);
            await db.SaveChangesAsync();
            return RedirectToAction("ScreeningMain");
        }

        [Authorize(Roles = "Director, Customer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Screening screening = await db.Screenings.FirstOrDefaultAsync(p => p.ScreeningId == id);
                if (screening != null)
                {
                    var vm = new ScreeningModel();
                    vm.Movies = db.Movies
                                          .Select(a => new SelectListItem()
                                          {
                                              Value = a.MovieId.ToString(),
                                              Text = a.Title
                                          })
                                          .ToList();
                    vm.Audithoriums = db.Audithoria
                              .Select(a => new SelectListItem()
                              {
                                  Value = a.AudithoriumId.ToString(),
                                  Text = a.Name
                              })
                              .ToList();
                    ViewBag.vm = vm.Movies;
                    ViewBag.vm1 = vm.Audithoriums;
                    return View(screening);
                }
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "Director, Customer")]
        public async Task<IActionResult> Edit(Screening screening)
        {
            db.Screenings.Update(screening);
            await db.SaveChangesAsync();
            return RedirectToAction("ScreeningMain");
        }

        [HttpGet]
        [ActionName("Delete")]
        [Authorize(Roles = "Director, Customer")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Screening screening = await db.Screenings.FirstOrDefaultAsync(p => p.ScreeningId == id);
                if (screening != null)
                    return View(screening);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Director, Customer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Screening screening = await db.Screenings.FirstOrDefaultAsync(p => p.ScreeningId == id);
                if (screening != null)
                {
                    db.Screenings.Remove(screening);
                    await db.SaveChangesAsync();
                    return RedirectToAction("ScreeningMain");
                }
            }
            return NotFound();
        }

    }

}
