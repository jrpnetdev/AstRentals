using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AstRentals.Data.Infrastructure;

namespace AstRentals.Api.Controllers
{
    public class CarDropDownController : ApiController
    {
        private readonly ICarRepository _repo;

        public CarDropDownController(ICarRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<string> Get(string var)
        {

            IEnumerable<string> results = new List<string>();

            var cars = _repo.All();

            if (var == "make")
            {
                results = cars.Select(c => c.Make).ToList().Distinct().OrderBy(c => c);
            }
            else if (var == "model")
            {
                results = cars.Select(c => c.Model).ToList().Distinct().OrderBy(c => c);
            }
            else if (var == "year")
            {
                results = cars.Select(c => c.Year.ToString()).ToList().Distinct().OrderByDescending(c => c);
            }

            return results;
        }

    }
}
