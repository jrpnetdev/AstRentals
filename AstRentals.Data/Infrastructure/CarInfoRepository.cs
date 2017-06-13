using AstRentals.Data.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

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
