using System.Collections.Generic;
using AstRentals.Data.Entities;

namespace AstRentals.Api.Helpers
{
    public interface IRecommendedHelper
    {
        List<Car> GetRecommendedCars(int max);
    }
}