using AstRentals.Data.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AstRentals.Data.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AstRentalsContext _ctx;

        public OrderRepository(AstRentalsContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Order> All()
        {
            return _ctx.Orders;
        }

        public Order Find(Expression<Func<Order, bool>> predicate)
        {
            return _ctx.Orders.SingleOrDefault(predicate);
        }

        public IQueryable<Order> FindAll(Expression<Func<Order, bool>> predicate)
        {
            return _ctx.Orders.Where(predicate).AsQueryable();
        }

        public int Add(Order order)
        {
            _ctx.Orders.Add(order);

            _ctx.SaveChanges();

            return 0;
        }

        public int Delete(Order order)
        {
            _ctx.Orders.Remove(order);

            _ctx.SaveChanges();

            return 0;
        }
    }
}
