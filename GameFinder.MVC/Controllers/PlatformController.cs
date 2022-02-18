using GameFinder.Models.PlatformModels;
using GameFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameFinder.MVC.Controllers
{
    public class PlatformController : Controller
    {
        // GET: Platform
        public ActionResult Index()
        {
            var svc = CreateService();
            var list = svc.GetPlatforms();
            return View(list);
        }

        // GET: Platform/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Platform/Create
        public ActionResult Create(PlatformCreate model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var svc = CreateService();

            if (svc.CreatePlatform(model))
            {
                TempData["SaveResult"] = "Successfully created platform.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not create platform.");

            return View(model);
        }

        // GET: Platform/Detail/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateService();
            var model = svc.GetPlatformById(id);

            return View(model);
        }

        // GET: Platform/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CreateService();
            var detail = svc.GetPlatformById(id);
            var model = new PlatformUpdate()
            {
                Name = detail.Name,
                Manufacturer = detail.Manufacturer,
                Medium = detail.Medium,
                LaunchDate = detail.LaunchDate,
                DiscontinueDate = detail.DiscontinueDate
            };

            return View(model);
        }

        // POST: Platform/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlatformUpdate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var svc = CreateService();

            if (svc.UpdatePlatform(id, model))
            {
                TempData["SaveResult"] = "Platform successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not update platform.");

            return View(model);
        }

        // GET: Platform/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateService();
            var detail = svc.GetPlatformById(id);

            return View(detail);
        }

        // POST: Platform/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePlatform(int id)
        {
            var svc = CreateService();

            svc.DeletePlatform(id);

            TempData["SaveResult"] = "Platform successfully deleted.";

            return RedirectToAction("Index");
        }

        private PlatformService CreateService()
        {
            var service = new PlatformService();
            return service;
        }
    }
}