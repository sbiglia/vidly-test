using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        //movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            var movies = _context.Movies.Include(c => c.MovieGenreType);

            return View(movies);
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Detail(int id)
        {
            var found = (from movie in _context.Movies.Include(c => c.MovieGenreType) where movie.Id == id select movie).FirstOrDefault();

            if (found == null)
            {
                return HttpNotFound();
            }


            return View(found);
        }
    }
}