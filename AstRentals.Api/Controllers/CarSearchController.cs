using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using AstRentals.Api.Models;
using AstRentals.Data.Entities;
using AstRentals.Data.Infrastructure;


namespace AstRentals.Api.Controllers
{
    public class CarSearchController : ApiController
    {
        private readonly AstRentalsContext _ctx;

        public CarSearchController(AstRentalsContext ctx)
        {
            _ctx = ctx;
        }

        public CarListViewModel Get(string searchText, int index, int size)
        {
            CarListViewModel clvm = new CarListViewModel();
            //Todo: Add a preprocessor to format input term

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

            //Todo: Add a preprocessor to format input term

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
