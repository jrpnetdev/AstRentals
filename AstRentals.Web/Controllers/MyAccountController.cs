using AstRentals.Data.Entities;
using AstRentals.Web.Helpers;
using AstRentals.Web.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AstRentals.Web.Controllers
{
    public class MyAccountController : Controller
    {
        public async Task<ActionResult> Index()
        {

            ViewBag.Email = CookieStore.GetCookie("Email");
            if (ViewBag.Email == "")
            {
                return RedirectToAction("Login", "Home");
            }

            MyAccountIndexViewModel model = new MyAccountIndexViewModel
            {
                Orders = await GetOrdersData(ViewBag.Email),
                FavouriteCars = await GetFavouritesData(ViewBag.Email)
            };

            if (model.FavouriteCars.Count == 0)
            {
                ViewBag.FavouritesError = "No favourites have been added.";
            }

            List<Car> cars = new List<Car>();

            if (model.Orders.Any())
            {
                foreach (var order in model.Orders)
                {
                    var car = await GetCar(order.CarId);
                    cars.Add(car);
                }

                model.OrderCars = cars;
            }

            if (model.Orders.Count == 0)
            {
                ViewBag.OrderError = "No orders have been placed.";
            }

            return View(model);

        }

        public async Task<ActionResult> Orders()
        {
            ViewBag.Email = CookieStore.GetCookie("Email");
            if (ViewBag.Email == "")
            {
                return RedirectToAction("Login", "Home");
            }

            var model = new MyAccountOrdersViewModel {Orders = await GetOrdersData(ViewBag.Email)};

            List<Car> cars = new List<Car>();

            if (model.Orders.Any())
            {
                foreach (var order in model.Orders)
                {
                    var car = await GetCar(order.CarId);
                    cars.Add(car);
                }

                model.Cars = cars;
            }

            if (model.Orders.Count == 0)
            {
                ViewBag.Error = "No orders have been placed.";
            }

            return View(model);
        }

        public async Task<ActionResult> Favourites()
        {
            ViewBag.Email = CookieStore.GetCookie("Email");
            if (ViewBag.Email == "")
            {
                return RedirectToAction("Login", "Home");
            }

            var model = await GetFavouritesData(ViewBag.Email);

            if (model.Count == 0)
            {
                ViewBag.Error = "No favourites have been added.";
            }

            return View(model);
        }

        public async Task<List<Order>> GetOrdersData(string email)
        {
            string temp = "";

            using (HttpClient client = new HttpClient())
            {
                temp = await client.GetStringAsync("http://localhost:50604/api/order?email=" + email + "&id=1");
            }

            var orders = JsonConvert.DeserializeObject<List<Order>>(temp);

            return orders;
        }

        public async Task<List<Car>> GetFavouritesData(string email)
        {
            string temp = "";

            using (HttpClient client = new HttpClient())
            {
                temp = await client.GetStringAsync("http://localhost:50604/api/favourites?email=" + email);
            }

            var cars = JsonConvert.DeserializeObject<List<Car>>(temp);

            return cars;
        }

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
    }

}