using AstRentals.Data.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AstRentals.Data.Infrastructure
{
    public interface IOrderRepository
    {
        IQueryable<Order> All();

        Order Find(Expression<Func<Order, bool>> predicate);

        IQueryable<Order> FindAll(Expression<Func<Order, bool>> predicate);

        int Add(Order favourite);

        int Delete(Order favourite);
    }
}
