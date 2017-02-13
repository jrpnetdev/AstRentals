using System;
using System.Collections.Generic;
using System.Linq;
using AstRentals.Data.Entities;
using AstRentals.Data.Infrastructure;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;

namespace AstRentals.Tests.Unit
{
    [TestFixture]
    public class CarRepositoryTests
    {
        public CarRepositoryTests()
        {

            IEnumerable<Car> cars = new List<Car>
            {
                new Car() { Id = 1, Year = 2013, Make = "Ford", Model = "Focus ST", ImageUrl = "https://www.example.com/img1.jpg" },
                new Car() { Id = 2, Year = 2013, Make = "Ford", Model = "Fusion", ImageUrl = "https://www.example.com/img2.jpg" },
                new Car() { Id = 3, Year = 2013, Make = "Ford", Model = "Mustang", ImageUrl = "https://www.example.com/img3.jpg" },
                new Car() { Id = 4, Year = 2012, Make = "Bentley", Model = "Continental GTC", ImageUrl = "https://www.example.com/img4.jpg" },
                new Car() { Id = 5, Year = 2012, Make = "Bentley", Model = "Continental Flying Spur", ImageUrl = "https://www.example.com/img5.jpg" },
                new Car() { Id = 6, Year = 2012, Make = "Bentley", Model = "Continental Super", ImageUrl = "https://www.example.com/img6.jpg" },
                new Car() { Id = 7, Year = 2012, Make = "Ford", Model = "Mustang", ImageUrl = "https://www.example.com/img7.jpg" },
                new Car() { Id = 8, Year = 2012, Make = "Ford", Model = "Transit Connect", ImageUrl = "https://www.example.com/img8.jpg" },
                new Car() { Id = 9, Year = 2012, Make = "Ford", Model = "Flex", ImageUrl = "https://www.example.com/img9.jpg" },
                new Car() { Id = 10, Year = 2012, Make = "Ford", Model = "Escape", ImageUrl = "https://www.example.com/img10.jpg" },
                new Car() { Id = 11, Year = 2012, Make = "Ford", Model = "Fusion", ImageUrl = "https://www.example.com/img11.jpg" },
                new Car() { Id = 12, Year = 2012, Make = "Ford", Model = "Taurus", ImageUrl = "https://www.example.com/img12.jpg" },
            };


            Mock<ICarRepository> mockCarRepository = new Mock<ICarRepository>();

            mockCarRepository.Setup(mr => mr.All()).Returns(cars.AsQueryable());

            mockCarRepository.Setup(mr => mr.Find(It.IsAny<Expression<Func<Car, bool>>>())).Returns((Expression<Func<Car, bool>> predicate) => cars.AsQueryable().Where(predicate).FirstOrDefault());

            mockCarRepository.Setup(mr => mr.FindAll(It.IsAny<Expression<Func<Car, bool>>>())).Returns((Expression<Func<Car, bool>> predicate) => cars.AsQueryable().Where(predicate));

            mockCarRepository.Setup(mr => mr.Count).Returns(cars.Count());

            MockCarsRepository = mockCarRepository.Object;

        }


        public readonly ICarRepository MockCarsRepository;


        [Test]
        public void CanReturnAllCars()
        {

            IEnumerable<Car> cars = MockCarsRepository.All();


            Assert.IsNotNull(cars); 

            Assert.AreEqual(12, cars.Count()); 
        }


        [Test]
        public void CanFindSingleCarByMakeAndModel()
        {
            Car result = MockCarsRepository.Find(c => c.Make == "Ford" && c.Model == "Flex");


            Assert.IsNotNull(result);

            Assert.IsInstanceOf<Car>(result); 

            Assert.AreEqual(2012, result.Year); 
        }


        [Test]
        public void CanReturnAllCarsByMake()
        {

            IEnumerable<Car> results = MockCarsRepository.FindAll(c => c.Make == "Ford");


            Assert.IsNotNull(results); 

            Assert.IsInstanceOf<Car>(results.FirstOrDefault());

            Assert.AreEqual(9, results.Count());

        }


        [Test]
        public void CanReturnCountOfAllCars()
        {

            int result = MockCarsRepository.Count;


            Assert.AreEqual(12, result);

        }

    }
}
