using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AstRentals.Data.Entities;
using AstRentals.Data.Infrastructure;

namespace AstRentals.Api.Controllers
{
    public class CarInfoController : ApiController
    {
        private readonly ICarInfoRepository _repo;

        public CarInfoController(ICarInfoRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<CarInfo> Get()
        {
            return _repo.All();
        }

        public CarInfo Get(string make, string model)
        {
            return _repo.Find(c => c.Make == make && c.Model == model);

        }
    }
}
