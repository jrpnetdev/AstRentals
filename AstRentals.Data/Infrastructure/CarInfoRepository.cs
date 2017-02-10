using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AstRentals.Data.Entities;

namespace AstRentals.Data.Infrastructure
{
    public class CarInfoRepository : ICarInfoRepository
    {
        private readonly AstRentalsContext _ctx;

        public CarInfoRepository(AstRentalsContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<CarInfo> All()
        {
            return _ctx.CarInfo;
        }

        public CarInfo Find(Expression<Func<CarInfo, bool>> predicate)
        {
            return _ctx.CarInfo.SingleOrDefault(predicate);
        }
    }
}
