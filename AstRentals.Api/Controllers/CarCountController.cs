using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AstRentals.Data.Infrastructure;

namespace AstRentals.Api.Controllers
{
    public class CarCountController : ApiController
    {
        private readonly ICarRepository _repo;

        public CarCountController(ICarRepository repo)
        {
            _repo = repo;
        }

        public int Get()
        {
            return _repo.Count;
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
