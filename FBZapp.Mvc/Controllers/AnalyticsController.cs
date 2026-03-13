using System.Web.Mvc;
using FBZapp.Infrastructure.Repositories;

namespace FBZapp.Mvc.Controllers
{
    public class AnalyticsController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            if (Session["Role"] == null || Session["Role"].ToString() != "Staff")
                return RedirectToAction("Index", "Home");

            var repo = new AnalyticsRepository();

            ViewBag.TopQueries = repo.GetTopSearchQueries();
            ViewBag.TopReturned = repo.GetTopReturnedComics();
            ViewBag.MoreThan100 = repo.GetComicsReturnedMoreThan100Times();

            return View();
        }
    }
}