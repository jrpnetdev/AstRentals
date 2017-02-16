using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AstRentals.Data.Entities;
using AstRentals.Api.Utilities;

namespace AstRentals.Tests.Unit
{
    [TestFixture]
    public class SearchUtilitiesTests
    {
        public SearchUtilitiesTests()
        {
            IEnumerable<Car> carlist = new List<Car>
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

            cars = carlist;
        }

        public readonly IEnumerable<Car> cars;

        [Test]
        public void ReturnsAllCarsWithMatchingMakeAndModel()
        {

            SearchUtilities sut = new SearchUtilities();

            var result = sut.TextSearch("Ford Mustang", cars);


            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void ReturnsAllCarsWithMatchingYearAndModel()
        {

            SearchUtilities sut = new SearchUtilities();

            var result = sut.TextSearch("2013 Fusion", cars);


            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void ReturnsAllCarsWithMatchingModelAndYear()
        {

            SearchUtilities sut = new SearchUtilities();

            var result = sut.TextSearch("Mustang 2012", cars);


            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void ReturnsAllCarsWithMatchingMakeModelAndYear()
        {

            SearchUtilities sut = new SearchUtilities();

            var result = sut.TextSearch("Ford Mustang 2012", cars);


            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void ReturnsAllCarsWithMatchingModelMakeAndYear()
        {

            SearchUtilities sut = new SearchUtilities();

            var result = sut.TextSearch("Mustang Ford 2012", cars);


            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void ReturnsAllCarsWithMatchingYearMakeAndModel()
        {

            SearchUtilities sut = new SearchUtilities();

            var result = sut.TextSearch("2012 Ford Mustang", cars);


            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void ReturnsAllCarsWithMatchingYearModelAndMake()
        {

            SearchUtilities sut = new SearchUtilities();

            var result = sut.TextSearch("2012 Mustang Ford", cars);


            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void ReturnsAllCarsWithMatchingYearAndMakel()
        {

            SearchUtilities sut = new SearchUtilities();

            var result = sut.TextSearch("2012 Bentley", cars);


            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void ReturnsAllCarsWithMatchingMake()
        {

            SearchUtilities sut = new SearchUtilities();

            var result = sut.TextSearch("Bentley", cars);


            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void ReturnsAllCarsWithMatchingYear()
        {

            SearchUtilities sut = new SearchUtilities();

            var result = sut.TextSearch("2013", cars);


            Assert.AreEqual(3, result.Count());
        }
    }
}
