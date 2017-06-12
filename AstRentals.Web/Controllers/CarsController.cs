using AstRentals.Data.Entities;
using AstRentals.Web.ViewModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AstRentals.Web.Controllers
{
    public class CarsController : Controller
    {
        //[Authorize]
        public ActionResult Index()
        {
            ViewBag.Email = TempData["email"] ?? "null";

            return View();
        }

        public ActionResult Details(int? id, string email)
        {

            ViewBag.Email = email;

            if (id == null || email == "null")
            {
                return RedirectToAction("Index", "Error");
            }

            DetailsViewModel vm = new DetailsViewModel() { Email = email, CarId = id };
            
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
            TempData["email"] = email;
        }
        #endregion
    }
}