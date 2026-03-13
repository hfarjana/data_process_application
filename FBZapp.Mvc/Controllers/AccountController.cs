
using FBZapp.Application.Services;
using FBZapp.Infrastructure.Repositories;
using FBZapp.Mvc.Models;
using System.Web.Mvc;

namespace FBZapp.Mvc.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userRepo = new UserRepository();
            var authService = new AuthService(userRepo);

            var success = authService.Register(model.Username, model.Password, model.Role);

            if (!success)
            {
                ViewBag.Message = "Username already exists.";
                return View(model);
            }

            ViewBag.Message = "User registered successfully.";
            return View(new RegisterViewModel());
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userRepo = new UserRepository();
            var authService = new AuthService(userRepo);

            var user = authService.Login(model.Username, model.Password);

            if (user == null)
            {
                ViewBag.Message = "Invalid username or password.";
                return View(model);
            }

            Session["UserId"] = user.Id;
            Session["Username"] = user.Username;
            Session["Role"] = user.Role;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}