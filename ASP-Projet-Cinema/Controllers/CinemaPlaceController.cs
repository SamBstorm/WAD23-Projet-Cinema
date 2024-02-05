using ASP_Projet_Cinema.Handlers;
using ASP_Projet_Cinema.Models;
using BLL_Projet_Cinema.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared_Projet_Cinema.Repositories;

namespace ASP_Projet_Cinema.Controllers
{
    public class CinemaPlaceController : Controller
    {
        private readonly ICinemaPlaceRepository<CinemaPlace> _cinemaPlaceRepository;

        public CinemaPlaceController(ICinemaPlaceRepository<CinemaPlace> cinemaPlaceRepository)
        {
            _cinemaPlaceRepository = cinemaPlaceRepository;
        }

        // GET: CinemaPlaceController
        public ActionResult Index()
        {
            IEnumerable<CinemaPlaceListItem> model = _cinemaPlaceRepository.Get().Select(d => d.ToListItem());
            return View(model);
        }

        // GET: CinemaPlaceController/Details/5
        public ActionResult Details(int id)
        {
            CinemaPlaceDetails model = _cinemaPlaceRepository.Get(id).ToDetails();
            return View(model);
        }

        // GET: CinemaPlaceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CinemaPlaceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CinemaPlaceCreateForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                int id = _cinemaPlaceRepository.Insert(form.ToBLL());
                return RedirectToAction(nameof(Details), new {id});
            }
            catch
            {
                return View();
            }
        }

        // GET: CinemaPlaceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CinemaPlaceController/Edit/5
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

        // GET: CinemaPlaceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CinemaPlaceController/Delete/5
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
