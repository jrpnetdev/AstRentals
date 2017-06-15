using AstRentals.Data.Entities;
using AstRentals.Web.ViewModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using AstRentals.Web.Helpers;

namespace AstRentals.Web.Controllers
{
    public class CarsController : Controller
    {
        //[Authorize]
        public ActionResult Index()
        {
            ViewBag.Email = CookieStore.GetCookie("Email");

            if (ViewBag.Email == "")
            {
                ViewBag.Email = "null";
            }

            return View();
        }

        public ActionResult Details(int? id)
        {

            ViewBag.Email = CookieStore.GetCookie("Email");
            if (ViewBag.Email == "")
            {
                ViewBag.Email = "null";
            }

            if (ViewBag.Email == "null")
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return RedirectToAction("Index", "Error");
            }

            DetailsViewModel vm = new DetailsViewModel() { Email = ViewBag.Email, CarId = id };
            
            return View(vm);
        }

        public async Task<ActionResult> Checkout(CheckoutViewModel vm)
        {
            var carstr = await GetCar(vm.CarId);

            vm.Car = JsonConvert.DeserializeObject<Car>(carstr);

            vm.StartDate = DateTime.Now;
            vm.EndDate = DateTime.Now.AddDays(7);

            return View(vm);
        }

        public async Task<ActionResult> Confirmation(CheckoutViewModel vm)
        {
            var carstr = await GetCar(vm.CarId);

            vm.Car = JsonConvert.DeserializeObject<Car>(carstr);

            vm.StartDate = DateTime.Now;
            vm.EndDate = DateTime.Now.AddDays(7);

            return View(vm);
        }

        public ActionResult Logout()
        {
            var responseCookie = HttpContext.Response.Cookies["Email"];
            if (responseCookie != null)
                responseCookie.Expires = DateTime.Now.AddDays(-1);

            return RedirectToAction("Index");
        }

        #region Helpers

        public async Task<string> GetCar(int id)
        {
            string temp = "";

            using (HttpClient client = new HttpClient())
            {
                temp = await client.GetStringAsync("http://localhost:50604/api/cars?id=" + id);
            }

            return temp;
        }

        [HttpPost]
        public void AddEmailToTempData(string email)
        {
            CookieStore.SetCookie("Email", email, TimeSpan.FromDays(1));
            //TempData["email"] = email;
        }
        #endregion
    }
}