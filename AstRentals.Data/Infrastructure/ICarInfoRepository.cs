using AstRentals.Data.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AstRentals.Data.Infrastructure
{
    public interface ICarInfoRepository
    {
        IQueryable<CarInfo> All();

        CarInfo Find(Expression<Func<CarInfo, bool>> predicate);
    }
}
