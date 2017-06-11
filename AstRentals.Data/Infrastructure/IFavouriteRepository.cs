using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AstRentals.Data.Entities;

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
