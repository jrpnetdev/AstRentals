using AstRentals.Data.Entities;
using AstRentals.Data.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace AstRentals.Api.Controllers
{
    public class OrdersController : ApiController
    {

        private readonly IOrderRepository _repo;

        public OrdersController(IOrderRepository repo)
        {
            _repo = repo;
        }

        public List<Order> Get(string email)
        {
            return _repo.FindAll(f => f.Email == email).ToList();
        }

        [HttpPost]
        public int Post([FromBody]Order order)
        {
            if (order.Email == "null") return 0;

            _repo.Add(order);

            return 1;
        }

        [HttpDelete]
        public int Delete(int id, string email)
        {
            var order = _repo.Find(o => o.Id == id && o.Email == email);

            _repo.Delete(order);

            return 1;
        }

    }
}
