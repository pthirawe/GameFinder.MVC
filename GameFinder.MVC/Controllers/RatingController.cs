using GameFinder.Models;
using GameFinder.Models.RatingModels;
using GameFinder.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameFinder.MVC.Controllers
{
    [Authorize]
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index()
        {
            var svc = CreateService();
            var list = svc.GetRatings();

            return View(list);
        }

        // GET: Rating/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rating/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatingCreate model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var svc = CreateService();
            if (svc.CreateRating(model))
            {
                TempData["SaveResult"] = "Rating was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unable to create rating.");

            return View(model);
        }

        // GET: Rating/Detail/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateService();
            var detail = svc.GetRatingById(id);

            return View(detail);
        }

        // GET: Rating/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CreateService();
            var detail = svc.GetRatingById(id);

            if (detail.AuthorId != Guid.Parse(User.Identity.GetUserId()))
            {
                TempData["SaveResult"] = "Unable to edit another's rating.";
                return RedirectToAction("Index");
            }

            var model = new RatingUpdate()
            {
                GameId = detail.GameId,
                Review = detail.Review,
                VisualScore = detail.VisualScore,
                GameplayScore = detail.GameplayScore,
                SoundScore = detail.SoundScore,
            };
            return View(model);
        }

        // POST: Rating/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RatingUpdate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var svc = CreateService();

            if (svc.UpdateRating(id,model))
            {
                TempData["SaveResult"] = "Rating was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not update rating.");

            return View(model);
        }

        // GET: Rating/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateService();
            var detail = svc.GetRatingById(id);

            if (detail.AuthorId != Guid.Parse(User.Identity.GetUserId()))
            {
                TempData["SaveResult"] = "Unable to edit another's rating.";
                return RedirectToAction("Index");
            }

            return View(detail);
        }

        // POST: Rating/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRating(int id)
        {
            var svc = CreateService();

            svc.DeleteRating(id);

            TempData["SaveResult"] = "Rating was deleted.";

            return RedirectToAction("Index");
        }

        private RatingService CreateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userName = User.Identity.GetUserName();
            var service = new RatingService(userId, userName);

            return service;
        }
    }
}