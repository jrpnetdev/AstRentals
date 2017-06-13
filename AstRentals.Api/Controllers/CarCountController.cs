using AstRentals.Api.Models;
using AstRentals.Data.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AstRentals.Api.Controllers
{
    public class CarCountController : ApiController
    {
        private readonly ICarRepository _repo;

        public CarCountController(ICarRepository repo)
        {
            _repo = repo;
        }

        public List<CarMakeCount> Get()
        {
            //return _repo.Count;

            var cars = _repo.All();

            var grouped = cars.GroupBy(c => c.Make)
                .Select(g => new CarMakeCount()
                {
                    Make = g.Key,
                    Count = g.Select(c => c).Distinct().Count()
                }).ToList();

            return grouped;
        }

        public int Get(string make)
        {
            return _repo.FindAll(c => c.Make == make).ToList().Count;
        }

        public int Get(int year)
        {
            return _repo.FindAll(c => c.Year == year).ToList().Count;
        }

        public int Get(string make, int year)
        {
            return _repo.FindAll(c => c.Make == make && c.Year == year).ToList().Count;
        }
    }
}
