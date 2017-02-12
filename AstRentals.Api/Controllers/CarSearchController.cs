using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AstRentals.Api.Utilities;
using AstRentals.Data.Entities;
using AstRentals.Data.Infrastructure;

namespace AstRentals.Api.Controllers
{
    public class CarSearchController : ApiController
    {
        private readonly ICarRepository _repo;

        public CarSearchController(ICarRepository repo)
        {
            _repo = repo;
        }

        //http://localhost:50604/api/carsearch?searchtext=Ford%20Mustang
        //http://localhost:50604/api/carsearch?searchtext=Ford%20Mustang%201989
        //http://localhost:50604/api/carsearch?searchtext=Mustang%202005
        public object Get(string searchText)
        {
            var allCars = _repo.All();

            if (String.IsNullOrWhiteSpace(searchText))
            {
                return allCars;
            }

            SearchUtilities utils = new SearchUtilities();

            var results = utils.TextSearch(searchText, allCars);

            if (!results.Any())
            {
                // Todo: What to return ???
            }

            // Todo: return CarListViewModel

            return results;
        }
    }
}
