using System.Linq;
using System.Web.Http;
using AstRentals.Data.Infrastructure;

namespace AstRentals.Api.Controllers
{
    public class CarInfoController : ApiController
    {
        private readonly ICarRepository _repo;

        public CarInfoController(ICarRepository repo)
        {
            _repo = repo;
        }

        public object Get()
        {
            var cars = _repo.All();

            var results = cars.Select(c => new { c.Make, c.Model }).Distinct().ToList();

            return results;
        }
    }
}
