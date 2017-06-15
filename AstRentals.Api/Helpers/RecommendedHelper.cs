using AstRentals.Data.Entities;
using AstRentals.Data.Infrastructure;
using System;
using System.Collections.Generic;

namespace AstRentals.Api.Helpers
{
    public class RecommendedHelper : IRecommendedHelper
    {
        private readonly ICarRepository _repository;

        public RecommendedHelper(ICarRepository repository)
        {
            _repository = repository;
        }

        private readonly Random _random = new Random();

        public List<Car> GetRecommendedCars(int max)
        {
            List<Car> recommendedCars = new List<Car>();

            for (int i = 0; i < 6; i++)
            {
                int id = _random.Next(1, max);
                var car = _repository.Find(c => c.Id == id);
                recommendedCars.Add(car);
            }

            return recommendedCars;
        }
    }
}