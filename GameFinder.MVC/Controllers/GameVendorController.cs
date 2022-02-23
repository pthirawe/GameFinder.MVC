using GameFinder.Models.JoiningModels;
using GameFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameFinder.MVC.Controllers
{
    public class GameVendorController : Controller
    {
        // GET: GameVendor
        public ActionResult Index()
        {
            var svc = CreateService();
            var list = svc.GetGameVendors();

            return View(list);
        }

        // GET: GameVendor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameVendor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameVendorCreate model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var svc = CreateService();

            if (svc.CreateGameVendor(model))
            {
                TempData["SaveResult"] = "Successfully added game vendor.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not add game vendor.");

            return View(model);
        }

        // GET: GameVendor/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateService();
            var detail = svc.GetGameVendorByID(id);

            return View(detail);
        }

        // GET: GameVendor/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CreateService();
            var detail = svc.GetGameVendorByID(id);
            var model = new GameVendorUpdate()
            {
                GameId = detail.GameId,
                VendorId = detail.VendorId,
                Price = detail.Price,
                Link = detail.Link
            };

            return View(model);
        }

        // POST: GameVendor/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameVendorUpdate model)
        {
            if(!ModelState.IsValid)
                return RedirectToAction("Index");

            var svc = CreateService();

            if (svc.UpdateGameVendor(id, model))
            {
                TempData["SaveResult"] = "Successfully updated game vendor.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not update game vendor.");

            return View(model);
        }

        // GET: GameVendor/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateService();
            var detail = svc.GetGameVendorByID(id);

            return View(detail);
        }

        // POST: GameVendor/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGameVendor(int id)
        {
            var svc = CreateService();
            
            svc.DeleteGameVendor(id);

            TempData["SaveResult"] = "Successfully removed game vendor.";

            return RedirectToAction("Index");
        }

        private GameVendorService CreateService()
        {
            var service = new GameVendorService();
            return service;
        }
    }
}