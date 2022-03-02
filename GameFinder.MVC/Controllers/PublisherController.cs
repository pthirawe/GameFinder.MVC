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
    public class PublisherController : Controller
    {
        // GET: Publisher
        public ActionResult Index()
        {
            var svc = CreateService();
            var list = svc.GetPublishers();
            return View(list);
        }

        // GET: Publisher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publisher/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PublisherCreate model)
        {
            if(!ModelState.IsValid)
                return View(model);
            
            var svc = CreateService();

            if (svc.CreatePublisher(model))
            {
                TempData["SaveResult"] = "Publisher was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Publisher could not be created.");

            return View(model);
        }

        // GET: Publisher/Detail/{id}
        public ActionResult Detail(int id)
        {
            var svc = CreateService();
            var model = svc.GetPublisherById(id);

            return View(model);
        }

        // GET: Publisher/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CreateService();
            var detail = svc.GetPublisherById(id);

            var model = new PublisherUpdate()
            {
                Name = detail.Name,
                Description = detail.Description,
                Link = detail.Link
            };
            return View(model);
        }

        // POST: Publisher/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PublisherUpdate model)
        {
            var svc = CreateService();

            if (!ModelState.IsValid)
                return View(model);

            if (svc.UpdatePublisher(id, model))
            {
                TempData["SaveResult"] = "Publisher was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Publisher could not be updated.");

            return View(model);
        }

        // GET: Publisher/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateService();
            var detail = svc.GetPublisherById(id);

            return View(detail);
        }

        // POST: Publisher/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePublisher(int id)
        {
            var svc = CreateService();
            
            svc.DeletePublisher(id);

            TempData["SaveResult"] = "Publisher was deleted.";

            return RedirectToAction("Index");
        }

        private PublisherService CreateService()
        {
            var service = new PublisherService();
            return service;
        }
    }
}