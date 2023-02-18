using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Models;
using System.Linq;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private MovieFormContext daContext { get; set; }

        //Constructor
        public HomeController(MovieFormContext someName)
        {
            daContext = someName;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {         
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = daContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(MovieFormResponse mfr)
        {
            if (ModelState.IsValid)
            {
                daContext.Add(mfr);
                daContext.SaveChanges();
                return View("Confirmation", mfr);
            }
            else //if invalid
            {
                ViewBag.Categories = daContext.Categories.ToList();
                return View(mfr);
            }

        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var forms = daContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(forms);
        }

        [HttpGet]
        public IActionResult Edit(int formid)
        {
            ViewBag.Categories = daContext.Categories.ToList();
            var form = daContext.Responses.Single(x => x.FormId == formid);
            return View("MovieForm", form);
        }

        [HttpPost]
        public IActionResult Edit (MovieFormResponse blah)
        {
            daContext.Update(blah);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int formid)
        {
            var form = daContext.Responses.Single(x => x.FormId == formid);
            return View(form);
        }

        [HttpPost]
        public IActionResult Delete(MovieFormResponse mfr)
        {
            daContext.Responses.Remove(mfr);
            daContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
