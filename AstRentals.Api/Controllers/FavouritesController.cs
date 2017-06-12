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
        private readonly ICarRepository _carRepo;

        public FavouritesController(IFavouriteRepository repo, ICarRepository carRepo)
        {
            _repo = repo;
            _carRepo = carRepo;
        }

        public List<Favourite> Get()
        {
            var favourites = _repo.All().ToList();

            return favourites;
        }

        public List<Car> Get(string email)
        {
            var favourites = _repo.FindAll(f => f.Email == email).ToList();

            return favourites.Select(favourite => _carRepo.Find(c => c.Id == favourite.CarId)).ToList();
        }

        [HttpPost]
        public int Post([FromBody]FavouritePost favourite)
        {
            if (favourite.Email == "null") return 0;

            // check for duplicates
            var favourites = _repo.FindAll(f => f.Email == favourite.Email).ToList();

            if (favourites.Any(item => item.CarId == favourite.CarId))
            {
                return 0;
            }

            _repo.Add(new Favourite() {CarId = favourite.CarId, Email = favourite.Email});

            return 1;
        }

        [HttpDelete]
        public int Delete(int id, string email)
        {
            var favourite = _repo.Find(f => f.CarId == id && f.Email == email);

            _repo.Delete(favourite);

            return 1;
        }

    }
}
