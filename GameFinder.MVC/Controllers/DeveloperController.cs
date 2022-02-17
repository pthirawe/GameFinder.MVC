using GameFinder.Models;
using GameFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameFinder.MVC.Controllers
{
    [Authorize]
    public class DeveloperController : Controller
    {
        // GET: Developer
        public ActionResult Index()
        {
            var svc = CreateService();
            var list = svc.GetDevelopers();

            return View(list);
        }

        // GET: Developer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Developer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeveloperCreate model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var svc = CreateService();
            if (svc.CreateDeveloper(model))
            {
                TempData["SaveResult"] = "Developer was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Developer could not be created.");

            return View(model);
        }

        // GET: Developer/Detail/ID
        public ActionResult Detail(int id)
        {
            var svc = CreateService();
            var model = svc.GetDeveloperById(id);


            return View(model);
        }

        // GET: Developer/Edit/ID
        public ActionResult Edit(int id)
        {
            var svc = CreateService();
            var detail = svc.GetDeveloperById(id);

            var model = new DeveloperUpdate()
            {
                Name = detail.Name,
                Description = detail.Description,
                Link = detail.Link
            };

            return View(model);
        }

        // POST: Developer/Edit/ID
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DeveloperUpdate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var svc = CreateService();

            if (svc.UpdateDeveloper(id, model))
            {
                TempData["SaveResult"] = "Developer Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Developer could not be updated.");

            return View(model);
        }

        // GET: Developer/Delete/ID
        public ActionResult Delete(int id)
        {
            var svc = CreateService();
            var model = svc.GetDeveloperById(id);

            return View(model);
        }

        // POST Developer/Delete/ID
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDev(int id)
        {
            var svc = CreateService();

            svc.DeleteDeveloper(id);

            TempData["SaveResult"] = "Developer was deleted.";

            return RedirectToAction("Index");
        }

        private DeveloperService CreateService()
        {
            var service = new DeveloperService();
            return service;
        }
    }
}