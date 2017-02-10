using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AstRentals.Data.Entities;

namespace AstRentals.Data.Infrastructure
{
    public interface ICarInfoRepository
    {
        IQueryable<CarInfo> All();

        CarInfo Find(Expression<Func<CarInfo, bool>> predicate);
    }
}
