using AstRentals.Data.Entities;
using AstRentals.Data.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace AstRentals.Api.Controllers
{
    public class OrderController : ApiController
    {

        private readonly IOrderRepository _repo;

        public OrderController(IOrderRepository repo)
        {
            _repo = repo;
        }

        public List<Order> Get(string email)
        {
            return _repo.FindAll(f => f.EmailAddress == email).ToList();
        }

        [HttpPost]
        public int Post([FromBody]Order order)
        {
            if (order.EmailAddress == "null") return 0;

            _repo.Add(order);

            return 1;
        }

        [HttpDelete]
        public int Delete(int id, string email)
        {
            var order = _repo.Find(o => o.Id == id && o.EmailAddress == email);

            _repo.Delete(order);

            return 1;
        }

    }
}
