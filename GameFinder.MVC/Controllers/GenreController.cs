using GameFinder.Models.GenreModels;
using GameFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameFinder.MVC.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre
        public ActionResult Index()
        {
            var svc = CreateService();
            var list = svc.GetGenres();

            return View(list);
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenreCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var svc = CreateService();

            if (svc.CreateGenre(model))
            {
                TempData["SaveResult"] = "Genre successfully created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not create genre.");

            return View(model);
        }

        // GET: Genre/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateService();
            var detail = svc.GetGenreById(id);

            return View(detail); 
        }

        // GET: Genre/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CreateService();
            var detail = svc.GetGenreById(id);

            var model = new GenreUpdate()
            {
                Name = detail.Name,
                Description = detail.Description
            };

            return View(model);
        }

        // POST: Genre/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GenreUpdate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var svc = CreateService();

            if (svc.GenreUpdate(id, model))
            {
                TempData["SaveResult"] = "Genre successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not update genre.");

            return View(model);
        }

        // GET: Genre/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateService();

            var detail = svc.GetGenreById(id);

            return View(detail);
        }

        // POST: Genre/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGenre(int id)
        {
            var svc = CreateService();

            svc.GenreDelete(id);

            TempData["SaveResult"] = "Genre successfully deleted.";

            return RedirectToAction("Index");
        }

        private GenreService CreateService()
        {
            var service = new GenreService();
            return service;
        }
    }
}