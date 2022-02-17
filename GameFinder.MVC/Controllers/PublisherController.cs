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

        public ActionResult Create()
        {
            return View();
        }

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

        private PublisherService CreateService()
        {
            var service = new PublisherService();
            return service;
        }
    }
}