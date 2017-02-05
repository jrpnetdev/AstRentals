using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AstRentals.Data.Entities;
using AstRentals.Data.Infrastructure;

namespace AstRentals.Api.Controllers
{
    //[Authorize]
    public class CarsController : ApiController
    {

        private readonly ICarRepository _repo;

        public CarsController(ICarRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Car> Get()
        {
            return _repo.All();
        }

        // GET api/cars?make=Ford&index=3&size=10
        public IEnumerable<Car> Get(string make, int index, int size)
        {
            //int cars = _repo.Count;
            var cars = _repo.FindAll(c => c.Make == make, index, size).OrderByDescending(c => c.Year).ToList();

            return cars;
        }

        // GET api/cars/5
        public Car Get(int id)
        {
            var car = _repo.Find(c => c.Id == id);

            return car;
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
