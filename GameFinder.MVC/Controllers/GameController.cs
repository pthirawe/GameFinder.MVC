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
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            var svc = CreateService();
            var games = svc.GetGames();

            return View(games);
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var svc = CreateService();
            svc.CreateGame(model);

            return RedirectToAction("Index");
        }

        // GET: Game/Details/ID
        public ActionResult Details(int id)
        {
            var svc = CreateService();
            var model = svc.GetGameById(id);

            return View(model);
        }

        // GET: Game/Edit/ID
        public ActionResult Edit(int id)
        {
            var svc = CreateService();
            var entity = svc.GetGameById(id);
            var model = new GameUpdate()
            {
                Title = entity.Title,
                Description = entity.Description,
                ReleaseDate = entity.ReleaseDate,
                DeveloperId = entity.DeveloperId,
                PublisherId = entity.PublisherId
            };
            return View(model);
        }

        // POST: Game/Edit/ID
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameUpdate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var svc = CreateService();
            if(svc.UpdateGame(id, model))
            {
                TempData["SaveResult"] = "Game was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Game could not be updtaed.");

            return View(model);
        }

        // GET: Game/Delete/ID
        public ActionResult Delete(int id)
        {
            var svc = CreateService();
            var model = svc.GetGameById(id);

            return View(model);
        }

        // POST: Game/Delete/ID
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGame(int id)
        {
            var svc = CreateService();

            svc.DeleteGame(id);

            TempData["SaveResult"] = "Game was deleted.";

            return RedirectToAction("Index");
        }

        private GameService CreateService()
        {
            var service = new GameService();
            return service;
        }
    }
}