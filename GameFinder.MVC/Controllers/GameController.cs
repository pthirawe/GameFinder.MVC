using GameFinder.Models;
using GameFinder.Services;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameFinder.MVC.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index(string title, string genre, string dev, string pub)
        {
            var svc = CreateService();
            var games = svc.GetGames();

            if(!String.IsNullOrEmpty(title))
                games = games.Where(g => g.Title.ToLower().Contains(title.ToLower()));

            if (!String.IsNullOrEmpty(genre))
                games = games.Where(g => g.Genre.Any(i=> i.ToLower().Contains(genre.ToLower())));

            if (!String.IsNullOrEmpty(dev))
                games = games.Where(g => g.Developer.ToLower().Contains(dev.ToLower()));

            if (!String.IsNullOrEmpty(pub))
                games = games.Where(g => g.Publisher.ToLower().Contains(pub.ToLower()));

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
        /*  Replaced by filters in index
        // GET: Game/Search
        public ActionResult Search()
        {
            dynamic query = new ExpandoObject();
            query.Search = new GameSearch();
            query.Results = new List<GameListItem>();

            return View();
        }

        // POST: Game/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(GameSearch query)
        {
            bool executed = false;
            var results = new List<GameListItem>();
            var svc = CreateService();

            if (query.Title != null)
            {
                results.AddRange(svc.GetGamesByTitle(query.Title));
                executed = true;
            }
            if (query.Developer != null)
            {
                results.AddRange(svc.GetGamesByDev(query.Developer));
                executed = true;
            }
            if (query.Publisher != null)
            {
                results.AddRange(svc.GetGamesByPublisher(query.Publisher));
                executed = true;
            }
            if (executed)
            {
                return RedirectToAction("SearchResults", "Game", results);
            }


            ModelState.AddModelError("", "Search terms are empty.");
            return View();
        }
        */
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