using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AstRentals.Data.Entities;

namespace AstRentals.Data.Infrastructure
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly AstRentalsContext _ctx;

        public FavouriteRepository(AstRentalsContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Favourite> All()
        {
            return _ctx.Favourites;
        }

        public Favourite Find(Expression<Func<Favourite, bool>> predicate)
        {
            return _ctx.Favourites.SingleOrDefault(predicate);
        }

        public IQueryable<Favourite> FindAll(Expression<Func<Favourite, bool>> predicate)
        {
            return _ctx.Favourites.Where(predicate).AsQueryable();
        }

        public int Add(Favourite favourite)
        {
            _ctx.Favourites.Add(favourite);

            _ctx.SaveChanges();

            return 0;
        }

        public int Delete(Favourite favourite)
        {
            _ctx.Favourites.Remove(favourite);

            _ctx.SaveChanges();

            return 0;
        }
    }
}
