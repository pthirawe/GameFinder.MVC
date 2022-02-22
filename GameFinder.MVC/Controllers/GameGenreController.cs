using GameFinder.Data;
using GameFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameFinder.MVC.Controllers
{
    public class GameGenreController : Controller
    {
        // GET: GameGenre
        public ActionResult Index()
        {
            var svc = CreateService();
            var list = svc.GetGameGenres();
            return View(list);
        }

        // GET: GameGenre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameGenre/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameGenre model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var svc = CreateService();

            if (svc.CreateGameGenre(model))
            {
                TempData["SaveResult"] = "Successfully added game genre.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not add game genre.");

            return View(model);
        }

        // GET: GameGenre/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateService();

            var entity = svc.GetGameGenreById(id);

            return View(entity);
        }

        // POST: GameGenre/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id)
        {
            var svc = CreateService();

            var entity = svc.GetGameGenreById(id);

            svc.DeleteGameGenre(id);

            TempData["SaveResult"] = "Successfully removed game genre.";

            return RedirectToAction("Index");
        }

        private GameGenreService CreateService()
        {
            var service = new GameGenreService();

            return service;
        }
    }
}