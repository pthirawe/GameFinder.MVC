using GameFinder.Data;
using GameFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameFinder.MVC.Controllers
{
    public class GameFeatureController : Controller
    {
        // GET: GameFeature
        public ActionResult Index()
        {
            var svc = CreateService();
            var list = svc.GetGameFeatures();
            return View(list);
        }

        // GET: GameFeature/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameFeature/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameFeature model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var svc = CreateService();

            if (svc.CreateGameFeature(model))
            {
                TempData["SaveResult"] = "Successfully added game feature.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not add game feature.");

            return View(model);
        }

        // GET: GameFeature/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateService();

            var entity = svc.GetGameFeatureById(id);

            return View(entity);
        }

        // POST: GameFeature/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id)
        {
            var svc = CreateService();

            var entity = svc.GetGameFeatureById(id);

            svc.DeleteGameFeature(id);

            TempData["SaveResult"] = "Successfully removed game feature.";

            return RedirectToAction("Index");
        }

        private GameFeatureService CreateService()
        {
            var service = new GameFeatureService();

            return service;
        }
    }
}