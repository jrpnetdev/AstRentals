using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Web;
using AstRentals.Data.Entities;


namespace AstRentals.Data.Infrastructure
{
    public class CarRepository : ICarRepository
    {

        private readonly AstRentalsContext _ctx;

        public CarRepository(AstRentalsContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Car> All()
        {
            return _ctx.Cars;
        }

        public Car Find(params object[] keys)
        {
            return _ctx.Cars.Find(keys);
        }

        public Car Find(Expression<Func<Car, bool>> predicate)
        {
            return _ctx.Cars.SingleOrDefault(predicate);
        }

        public IQueryable<Car> FindAll(Expression<Func<Car, bool>> predicate)
        {
            return _ctx.Cars.Where(predicate).AsQueryable();
        }

        public IQueryable<Car> FindAll(Expression<Func<Car, bool>> predicate, int index, int size)
        {
            var skip = (index-1) * size;

            IQueryable<Car> query = _ctx.Cars;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (skip != 0)
            {
                query = query.OrderBy(q => q.Id).Skip(skip);
            }

            return query.Take(size).AsQueryable();

        }

        public int Count
        {
           get { return _ctx.Cars.Count(); }
        }

        public int Update(Car car)
        {
            var entry = _ctx.Entry(car);

            _ctx.Cars.Attach(car);

            entry.State = EntityState.Modified;

            return _ctx.SaveChanges();
        }

    }
}