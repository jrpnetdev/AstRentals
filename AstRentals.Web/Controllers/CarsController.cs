using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace AstRentals.Web.Controllers
{
    public class CarsController : Controller
    {
        // GET: Cars
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index","Error");
            }

            return View(id);
        }

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult Confirmation()
        {
            return View();
        }
    }
}