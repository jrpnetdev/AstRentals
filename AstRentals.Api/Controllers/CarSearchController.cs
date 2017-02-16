using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AstRentals.Api.Models;
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
        public CarListViewModel Get(string searchText, int index, int size)
        {
            CarListViewModel clvm = new CarListViewModel();
            var allCars = _repo.All();

            if (String.IsNullOrWhiteSpace(searchText))
            {
                clvm.Cars = allCars;
            }

            SearchUtilities utils = new SearchUtilities();

            var results = utils.TextSearch(searchText, allCars);

            //if (!results.Any())
            //{
            //    // Todo: What to return ???
            //}

            clvm.TotalCars = results.Count();


            var skip = (index - 1) * size;

            if (skip != 0)
            {
                results = results.OrderBy(q => q.Id).Skip(skip);
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

        public IEnumerable<Car> Get(string searchText)
        {
            var allCars = _repo.All();

            //if (String.IsNullOrWhiteSpace(searchText))
            //{
            //    clvm.Cars = allCars;
            //}

            SearchUtilities utils = new SearchUtilities();

            var results = utils.TextSearch(searchText, allCars);

            return results;

        }
    }
}
