using System;
using System.Linq;
using System.Linq.Expressions;
using AstRentals.Data.Entities;

namespace AstRentals.Data.Infrastructure
{
    public interface ICarRepository
    {
        IQueryable<Car> All();

        Car Find(Expression<Func<Car, bool>> predicate);

        IQueryable<Car> FindAll(Expression<Func<Car, bool>> predicate);

        IQueryable<Car> FindAll(Expression<Func<Car, bool>> predicate, int index, int size);

        int Count { get; }

        int Update(Car car);
    }
}
