using ASP_Projet_Cinema.Handlers;
using ASP_Projet_Cinema.Models;
using BLL_Projet_Cinema.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared_Projet_Cinema.Repositories;

namespace ASP_Projet_Cinema.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository<Movie> _movieRepository;

        public MovieController(IMovieRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: MovieController
        public ActionResult Index()
        {
            IEnumerable<MovieListItem> model = _movieRepository.Get().Select(d => d.ToListItem());
            return View(model);
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            MovieDetails model = _movieRepository.Get(id).ToDetails();
            return View(model);
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
