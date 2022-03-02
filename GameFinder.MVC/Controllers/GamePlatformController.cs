using GameFinder.Data;
using GameFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameFinder.MVC.Controllers
{
    public class GamePlatformController : Controller
    {
        // GET: GamePlatform
        public ActionResult Index()
        {
            var svc = CreateService();
            var list = svc.GetGamePlatforms();
            return View(list);
        }

        // GET: GamePlatform/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GamePlatform/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GamePlatform model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var svc = CreateService();

            if (svc.CreateGamePlatform(model))
            {
                TempData["SaveResult"] = "Successfully added game platform.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not add game platform.");

            return View(model);
        }

        // GET: GamePlatform/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateService();

            var entity = svc.GetGamePlatformById(id);

            return View(entity);
        }

        // POST: GamePlatform/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id)
        {
            var svc = CreateService();

            var entity = svc.GetGamePlatformById(id);

            svc.DeleteGamePlatform(id);

            TempData["SaveResult"] = "Successfully removed game platform.";

            return RedirectToAction("Index");
        }

        private GamePlatformService CreateService()
        {
            var service = new GamePlatformService();

            return service;
        }
    }
}