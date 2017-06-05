using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using AstRentals.Data.Entities;
using AstRentals.Web.ViewModels;
using Newtonsoft.Json;

namespace AstRentals.Web.Controllers
{
    public class CarsController : Controller
    {
        //[Authorize]
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

        public async Task<string> GetCar(int id)
        {
            string temp = "";

            using (HttpClient client = new HttpClient())
            {
                temp = await client.GetStringAsync("http://localhost:50604/api/cars?id=" + id);
            }

            return temp;
        }
    }
}