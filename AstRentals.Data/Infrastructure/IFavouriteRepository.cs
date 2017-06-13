using AstRentals.Data.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AstRentals.Data.Infrastructure
{
    public interface IFavouriteRepository
    {
        IQueryable<Favourite> All();

        Favourite Find(Expression<Func<Favourite, bool>> predicate);

        IQueryable<Favourite> FindAll(Expression<Func<Favourite, bool>> predicate);

        int Add(Favourite favourite);

        int Delete(Favourite favourite);
    }
}
