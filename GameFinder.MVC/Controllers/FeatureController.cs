using GameFinder.Models.FeatureModels;
using GameFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameFinder.MVC.Controllers
{
    public class FeatureController : Controller
    {
        // GET: Feature
        public ActionResult Index()
        {
            var svc = CreateService();
            var list = svc.GetFeatures();

            return View(list);
        }

        // GET: Feature/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feature/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeatureCreate model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var svc = CreateService();

            if (svc.CreateFeature(model))
            {
                TempData["SaveResult"] = "Feature successfully created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not create feature.");

            return View(model);
        }

        // GET: Feature/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateService();
            return View(svc.GetFeatureById(id));
        }

        // GET: Feature/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CreateService();
            var entity = svc.GetFeatureById(id);

            return View(entity);
        }

        // POST: Feature/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FeatureUpdate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var svc = CreateService();

            if (svc.FeatureUpdate(id, model))
            {
                TempData["SaveResult"] = "Successfully updated feature.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unable to update feature.");

            return View(model);
        }

        // GET: Feature/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateService();
            var detail = svc.GetFeatureById(id);
            
            return View(detail);
        }

        // POST: Feature/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFeature(int id)
        {
            var svc = CreateService();
            
            svc.FeatureDelete(id);

            TempData["SaveResult"] = "Successfully deleted feature.";

            return RedirectToAction("Index");
        }

        private FeatureService CreateService()
        {
            var service = new FeatureService();
            return service;
        }
    }
}