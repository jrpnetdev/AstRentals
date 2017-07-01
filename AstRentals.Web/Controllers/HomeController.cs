using System.Web.Mvc;
using AstRentals.Web.Helpers;

namespace AstRentals.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            ViewBag.Email = CookieStore.GetCookie("Email");

            if (ViewBag.Email == "")
            {
                ViewBag.Email = "null";
            }

            return View();
        }

        public ActionResult Register()
        {

            ViewBag.Email = CookieStore.GetCookie("Email");

            if (ViewBag.Email == "")
            {
                ViewBag.Email = "null";
            }

            return View();
        }

    }
}