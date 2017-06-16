using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using AstRentals.Api.Helpers;
using AstRentals.Api.Models;
using AstRentals.Data.Entities;
using AstRentals.Data.Infrastructure;


namespace AstRentals.Api.Controllers
{
    public class CarSearchController : ApiController
    {
        private readonly AstRentalsContext _ctx;
        private readonly ICarRepository _repo;
        private readonly IRecommendedHelper _helper;

        public CarSearchController(AstRentalsContext ctx, ICarRepository repo, IRecommendedHelper helper)
        {
            _ctx = ctx;
            _repo = repo;
            _helper = helper;
        }

        public CarListViewModel Get(string searchText, int index, int size)
        {

            CarListViewModel clvm = new CarListViewModel();

            clvm.RecommendedCars = _helper.GetRecommendedCars(_repo.Count);

            var results = new List<Car>();

            using (var context = _ctx)
            {
                var clientIdParameter = new SqlParameter("@term", searchText);

                results = context.Database
                    .SqlQuery<Car>("dbo.SearchCars @term", clientIdParameter)
                    .ToList();
            }

            clvm.Cars = results;
            clvm.TotalCars = results.Count;

            var skip = (index - 1) * size;

            if (skip != 0)
            {
                results = results.OrderBy(q => q.Id).Skip(skip).ToList();
            }

            clvm.Cars = results.Take(size);

            var pages = clvm.TotalCars / size;
            var remainder = clvm.TotalCars % size;
            if (remainder != 0)
            {
                pages += 1;
            }

            clvm.NumberOfPages = pages;
            clvm.CurrentPage = index;

            return clvm;
        }

        public List<Car> Get(string term)
        {
            var result = new List<Car>();

            using (var context = _ctx)
            {
                var clientIdParameter = new SqlParameter("@term", term);

                result = context.Database
                    .SqlQuery<Car>("dbo.SearchCars @term", clientIdParameter)
                    .ToList();
            }

            return result;
        }
    }
}
