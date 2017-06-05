using AstRentals.Data.Entities;
using AstRentals.Data.Infrastructure;
using System.Collections.Generic;
using System.Linq;
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

        public List<Car> Get()
        {
            var allFavourites = _repo.All().ToList();

            var carList = new List<Car>();

            foreach (var favourite in allFavourites)
            {
                var car = _carRepo.Find(c => c.Id == favourite.CarId);
                carList.Add(car);
            }

            return carList;
        }

        [HttpPost]
        public int Post([FromBody]int id)
        {
            var car = _carRepo.Find(c => c.Id == id);

            _repo.Add(new Favourite() {CarId = car.Id});

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
