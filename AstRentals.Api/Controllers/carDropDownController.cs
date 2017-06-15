using AstRentals.Data.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AstRentals.Api.Controllers
{
    public class CarDropDownController : ApiController
    {
        private readonly ICarRepository _repo;

        public CarDropDownController(ICarRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<string> Get(string searchType)
        {

            IEnumerable<string> results = new List<string>();

            var cars = _repo.All();

            if (searchType == "make")
            {
                results = cars.Select(c => c.Make).ToList().Distinct().OrderBy(c => c);
            }
            else if (searchType == "model")
            {
                results = cars.Select(c => c.Model).ToList().Distinct().OrderBy(c => c);
            }
            else if (searchType == "year")
            {
                results = cars.Select(c => c.Year.ToString()).ToList().Distinct().OrderByDescending(c => c);
            }

            return results;
        }

        public IEnumerable<IEnumerable<string>> Get(string searchTerm, string searchType)
        {
            List<List<string>> results = new List<List<string>>();

            var cars = _repo.All();

            switch (searchType)
            {
                case "make":
                    results.Add(cars.Where(c => c.Make == searchTerm).Select(c => c.Make).Distinct().OrderBy(c => c).ToList());
                    results.Add(cars.Where(c => c.Make == searchTerm).Select(c => c.Model).Distinct().OrderBy(c => c).ToList());
                    results.Add(cars.Where(c => c.Make == searchTerm).Select(c => c.Year.ToString()).Distinct().OrderByDescending(c => c).ToList());
                    break;
                case "model":
                    results.Add(cars.Where(c => c.Model == searchTerm).Select(c => c.Make).Distinct().OrderBy(c => c).ToList());
                    results.Add(cars.Where(c => c.Model == searchTerm).Select(c => c.Model).Distinct().OrderBy(c => c).ToList());
                    results.Add(cars.Where(c => c.Model == searchTerm).Select(c => c.Year.ToString()).Distinct().OrderByDescending(c => c).ToList());
                    break;
                case "year":
                    results.Add(cars.Where(c => c.Year.ToString() == searchTerm).Select(c => c.Make).Distinct().OrderBy(c => c).ToList());
                    results.Add(cars.Where(c => c.Year.ToString() == searchTerm).Select(c => c.Model).Distinct().OrderBy(c => c).ToList());
                    results.Add(cars.Where(c => c.Year.ToString() == searchTerm).Select(c => c.Year.ToString()).Distinct().OrderByDescending(c => c).ToList());
                    break;
            }

            return results;
        }
    }
}
