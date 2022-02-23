using GameFinder.Models.VendorModels;
using GameFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameFinder.MVC.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendor
        public ActionResult Index()
        {
            var svc = CreateService();
            var list = svc.GetVendors();

            return View(list);
        }

        // GET: Vendor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendorCreate model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var svc = CreateService();

            if (svc.CreateVendor(model))
            {
                TempData["SaveResult"] = "Successfully created vendor.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not create vendor.");

            return View(model);
        }

        // GET: Vendor/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateService();
            var detail = svc.GetVendorById(id);

            return View(detail);
        }

        // GET: Vendor/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CreateService();
            var detail = svc.GetVendorById(id);

            var model = new VendorUpdate()
            {
                Name =  detail.Name,
                Description = detail.Description,
                Link = detail.Link
            };
            return View(model);
        }

        // POST: Vendor/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VendorUpdate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var svc = CreateService();
            
            if (svc.VendorUpdate(id, model))
            {
                TempData["SaveResult"] = "Successfully updated vendor.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not update vendor.");

            return View(model);
        }

        // GET: Vendor/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateService();
            var detail = svc.GetVendorById(id);

            return View(detail);
        }

        // POST: Vendor/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVendor(int id)
        {
            var svc = CreateService();

            svc.DeleteVendor(id);

            TempData["SaveResult"] = "Successfully deleted vendor.";

            return RedirectToAction("Index");
        }

        private VendorService CreateService()
        {
            var service = new VendorService();
            return service;
        }
    }
}