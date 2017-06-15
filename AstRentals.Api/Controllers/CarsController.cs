using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.Http;
using AstRentals.Api.Helpers;
using AstRentals.Api.Models;
using AstRentals.Data.Entities;
using AstRentals.Data.Infrastructure;

namespace AstRentals.Api.Controllers
{
    //[Authorize]
    public class CarsController : ApiController
    {
        private readonly ICarRepository _repo;
        private readonly IRecommendedHelper _helper;

        public CarsController(ICarRepository repo, IRecommendedHelper helper)
        {
            _repo = repo;
            _helper = helper;
        }

        public IEnumerable<Car> Get()
        {
            return _repo.All();
        }

        // GET api/cars?make=Ford&index=3&size=10
        public IEnumerable<Car> Get(string make)
        {
            return _repo.FindAll(c => c.Make == make).OrderByDescending(c => c.Year).ToList();
        }

        // GET api/cars?make=Bentley&size=10
        public CarListViewModel Get(string make, int index, int size)
        {
            CarListViewModel clvm = new CarListViewModel();

            var cars = _repo.FindAll(c => c.Make == make, index, size).OrderBy(c => c.Id).ToList();
            clvm.Cars = cars;

            clvm.TotalCars = _repo.FindAll(c => c.Make == make).Count();

            var pages = clvm.TotalCars / size;
            var remainder = clvm.TotalCars % size;
            if (remainder != 0)
            {
                pages += 1;
            }

            clvm.NumberOfPages = pages;
            clvm.CurrentPage = index;

            clvm.RecommendedCars = _helper.GetRecommendedCars(_repo.Count);

            return clvm;
        }

        // GET api/cars?make=Bentley&size=10
        public CarListViewModel Get(int year, int index, int size)
        {
            CarListViewModel clvm = new CarListViewModel();

            //int cars = _repo.Count;
            var cars = _repo.FindAll(c => c.Year == year, index, size).OrderBy(c => c.Id).ToList();
            clvm.Cars = cars;

            clvm.TotalCars = _repo.FindAll(c => c.Year == year).Count();

            var pages = clvm.TotalCars / size;
            var remainder = clvm.TotalCars % size;
            if (remainder != 0)
            {
                pages += 1;
            }

            clvm.NumberOfPages = pages;
            clvm.CurrentPage = index;

            clvm.RecommendedCars = _helper.GetRecommendedCars(_repo.Count);

            return clvm;
        }

        // GET api/cars/5
        public Car Get(int id)
        {
            return _repo.Find(c => c.Id == id);
        }

        // POST api/cars
        public void Post([FromBody]Car car)
        {
            _repo.Update(car);
        }

        // PUT api/cars/5
        public void Put(int id, [FromBody]Car car)
        {

        }

        // DELETE api/cars/5
        public void Delete(int id)
        {
        }
    }
}
