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
using Vidly.ViewModels.Customers;

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


        public ActionResult New()
        {
            var movieGenreTypes = _context.MovieGenreTypes;

            var viewModel = new MovieFormViewModel()
            {
                MovieGenreTypes = movieGenreTypes
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {

                var viewModel = new MovieFormViewModel(movie)
                {
                    MovieGenreTypes = _context.MovieGenreTypes
                };

                return View("MovieForm", viewModel);

            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.MovieGenreTypeId = movie.MovieGenreTypeId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [Route("Movies/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                MovieGenreTypes = _context.MovieGenreTypes
            };

            return View("MovieForm", viewModel);
        }
    }
}