using AstRentals.Data.Entities;
using AstRentals.Data.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace AstRentals.Api.Controllers
{
    public class FavouritesController : ApiController
    {

        private readonly IFavouriteRepository _repo;

        public FavouritesController(IFavouriteRepository repo)
        {
            _repo = repo;
        }

        public List<Favourite> Get(string email)
        {
            var favourites = _repo.FindAll(p => p.Email == email).ToList();

            return favourites;
        }

        [HttpPost]
        public int Post([FromBody]FavouritePost favourite)
        {
            if (favourite.Email == "null") return 0;

            _repo.Add(new Favourite() {CarId = favourite.CarId, Email = favourite.Email});

            return 1;
        }

        public int Delete(string s, int id)
        {
            var favourite = _repo.Find(f => f.CarId == id);

            _repo.Delete(favourite);

            return 1;
        }

    }
}
