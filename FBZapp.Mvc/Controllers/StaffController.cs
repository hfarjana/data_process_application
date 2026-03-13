using FBZapp.Domain.Entities;
using FBZapp.Infrastructure.Repositories;
using System;
using System.Web.Mvc;
using static FBZapp.Domain.Entities.Comic;

namespace FBZapp.Mvc.Controllers
{
    public class StaffController : Controller
    {
        [HttpPost]
        public ActionResult FlagComic(string comicTitle, string flagReason)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            if (Session["Role"] == null || Session["Role"].ToString() != "Staff")
                return RedirectToAction("Index", "Home");

            var userId = (int)Session["UserId"];

            var repo = new FlagRepository();
            repo.AddFlag(new FlaggedRecord
            {
                ComicTitle = comicTitle,
                FlagReason = flagReason,
                FlaggedByUserId = userId,
                FlaggedDate = DateTime.Now
            });

            return RedirectToAction("Index", "Comics");
        }

        public ActionResult Flags()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            if (Session["Role"] == null || Session["Role"].ToString() != "Staff")
                return RedirectToAction("Index", "Home");

            var repo = new FlagRepository();
            var flags = repo.GetAllFlags();

            return View(flags);
        }
    }
}