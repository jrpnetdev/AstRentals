using AstRentals.Data.Entities;
using AstRentals.Web.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using AstRentals.Web.Helpers;

namespace AstRentals.Web.Controllers
{
    public class CarsController : Controller
    {
        public ActionResult Index()
        {
            DeleteCheckoutCookie();

            ViewBag.Email = CookieStore.GetCookie("Email");

            if (ViewBag.Email == "")
            {
                ViewBag.Email = "null";
            }

            return View();
        }

        public async Task<ActionResult> Details(int? id)
        {
            DeleteCheckoutCookie();

            ViewBag.Email = CookieStore.GetCookie("Email");
            if (ViewBag.Email == "")
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return RedirectToAction("Index", "Error");
            }

            //Check if favourite added to display correct link in view
            ViewBag.FavouriteAdded = false;

            List<Car> cars = await GetFavourites(ViewBag.Email);

            if (cars.Any())
            {
                foreach (var car in cars)
                {
                    if (car.Id == id)
                    {
                        ViewBag.FavouriteAdded = true;
                    }
                } 
            }

            var vm = new DetailsViewModel() { Email = ViewBag.Email, CarId = id };
            
            return View(vm);
        }

        [HttpPost]
        public void PreCheckout(PreCheckoutModel vm)
        {
            if (vm.EndDate == "null")
            {
                CookieStore.SetCookie("CheckoutDetails", "NoEndDate:" + vm.CarId, TimeSpan.FromDays(1));
                return;
            }

            var json = JsonConvert.SerializeObject(vm);

            CookieStore.SetCookie("CheckoutDetails", json, TimeSpan.FromDays(1));
        }

        public async Task<ActionResult> Checkout()
        {
            var json = CookieStore.GetCookie("CheckoutDetails");

            // check if CheckoutDetails json is valid
            if(json == "")
            {
                DeleteCheckoutCookie();
                return RedirectToAction("Index", "Cars");
            }
            if(json.StartsWith("NoEndDate:"))
            {
                string[] words = json.Split(':');
                var returnId = Convert.ToInt32(words[1]);
                DeleteCheckoutCookie();
                TempData["Error"] = "No End Date was selected";
                return RedirectToAction("Details", "Cars", new { id = returnId });
            }

            var preCheckoutVm = JsonConvert.DeserializeObject<PreCheckoutModel>(json);

            var helper = new CheckoutViewModelHelper();
            var vm = helper.CreateCheckoutViewModel(preCheckoutVm);

            var email = CookieStore.GetCookie("Email");
            if (email == "")
            {
                DeleteCheckoutCookie();
                return RedirectToAction("Login", "Home");
            }

            vm.EmailAddress = email;
            ViewBag.Email = email;  //Required for favourites

            ViewBag.Car = await GetCar(vm.CarId);

            DeleteCheckoutCookie();

            return View(vm);
        }

        public async Task<ActionResult> Confirmation()
        {

            //Get email address from cookie
            var email = CookieStore.GetCookie("Email");
            if (email == "")
            {
                DeleteCheckoutCookie();
                return RedirectToAction("Login", "Home");
            }

            ViewBag.Email = email;  //Required for favourites

            var vm = await GetLatestOrder(email);

            ViewBag.Car = await GetCar(vm.CarId);

            return View(vm);
        }

        public ActionResult Logout()
        {
            var responseCookie = HttpContext.Response.Cookies["Email"];
            if (responseCookie != null)
                responseCookie.Expires = DateTime.Now.AddDays(-1);

            DeleteCheckoutCookie();

            return RedirectToAction("Index");
        }

        #region Helpers

        public async Task<Car> GetCar(int id)
        {
            string temp = "";

            using (HttpClient client = new HttpClient())
            {
                temp = await client.GetStringAsync("http://localhost:50604/api/cars?id=" + id);
            }

            var car = JsonConvert.DeserializeObject<Car>(temp);
            return car;
        }

        public async Task<CheckoutViewModel> GetLatestOrder(string email)
        {
            string temp = "";

            using (HttpClient client = new HttpClient())
            {
                temp = await client.GetStringAsync("http://localhost:50604/api/order?email=" + email);
            }

            var order = JsonConvert.DeserializeObject<CheckoutViewModel>(temp);

            return order;
        }

        public async Task<List<Car>> GetFavourites(string email)
        {
            string temp = "";

            using (HttpClient client = new HttpClient())
            {
                temp = await client.GetStringAsync("http://localhost:50604/api/favourites?email=" + email);
            }

            var cars = JsonConvert.DeserializeObject<List<Car>>(temp);

            return cars;
        }

        [HttpPost]
        public void AddEmailToCookie(string email)
        {
            CookieStore.SetCookie("Email", email, TimeSpan.FromDays(1));
        }

        private void DeleteCheckoutCookie()
        {
            var checkoutCookie = HttpContext.Response.Cookies["CheckoutDetails"];
            if (checkoutCookie != null)
                checkoutCookie.Expires = DateTime.Now.AddDays(-1);
        }
        #endregion
    }
}