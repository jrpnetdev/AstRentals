using AstRentals.Api.Helpers;
using AstRentals.Data.Entities;
using AstRentals.Data.Infrastructure;
using System.Collections.Generic;
using System.Web.Http;

namespace AstRentals.Api.Controllers
{
    public class CarDetailsController : ApiController
    {
        private readonly ICarRepository _repo;
        private readonly IRecommendedHelper _helper;

        public CarDetailsController(ICarRepository repo, IRecommendedHelper helper)
        {
            _repo = repo;
            _helper = helper;
        }

        public List<Car> Get()
        {
            var cars = _helper.GetRecommendedCars(_repo.Count);

            return cars;
        }
    }
}
