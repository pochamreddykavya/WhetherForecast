using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using ResfulCrudOperations.Controllers;
using ResfulCrudOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WhetherForecastTest.Controllers
{

    [TestFixture]
    public class CityControllerTests
    {
        [Test]
        public void AddCity_via_context()
        {
            var mockCity = new Mock<DbSet<City>>();

            var mockContext = new Mock<WhetherForecastDBContext>();
            mockContext.Setup(m => m.City).Returns(mockCity.Object);
            City city = new City();
            city.CityId = 1;
            var controller = new CityController(mockContext.Object);
            controller.AddCity(city);

            mockCity.Verify(m => m.Add(It.IsAny<City>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void DeleteCity_via_context()
        {
            var data = new List<City>
            {
                new City()
                {
                CityId = 1,
                CityName = "city2",
                DateEstablished = Convert.ToDateTime("2023-1-20"),
                State="UK",
                TouristRating=5,
                EstimatedPopulation="1000",
                }
            }.AsQueryable();



            var mockSet = new Mock<DbSet<City>>();
            mockSet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<WhetherForecastDBContext>();
            mockContext.Setup(c => c.City).Returns(mockSet.Object);
            var controller = new CityController(mockContext.Object);

            controller.DeleteCity(1);

            mockSet.Verify(m => m.Remove(It.IsAny<City>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void UpdateCity_via_context()
        {
            var data = new List<City>
            {
                new City()
                {
                CityId = 1,
                CityName = "city2",
                DateEstablished = Convert.ToDateTime("2023-1-20"),
                State="UK",
                TouristRating=5,
                EstimatedPopulation="1000",
                }
            }.AsQueryable();



            var mockSet = new Mock<DbSet<City>>();
            mockSet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<WhetherForecastDBContext>();
            mockContext.Setup(c => c.City).Returns(mockSet.Object);

            var controller = new CityController(mockContext.Object);
            controller.UpdateCity(data.FirstOrDefault());

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void SearchCity_via_context()
        {

            var data = new List<City>
            {
                new City()
                {
                CityId = 1,
                CityName = "city2",
                DateEstablished = Convert.ToDateTime("2023-1-20"),
                State="UK",
                TouristRating=5,
                EstimatedPopulation="1000",
                }
            }.AsQueryable();



            var mockSet = new Mock<DbSet<City>>();
            mockSet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());


            var countryData = new List<Country>
            {
                new Country()
                {
                
                  CountryId = 1, CountryName = "UnitedKingdom", ThreeDigitCountryCode = "UKG", TwoDigitCountryCode = "44",
               
                }
            }.AsQueryable();

            var mockSetCountry = new Mock<DbSet<Country>>();
            mockSetCountry.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(countryData.Provider);
            mockSetCountry.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(countryData.Expression);
            mockSetCountry.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(countryData.ElementType);
            mockSetCountry.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(() => countryData.GetEnumerator());

            var whetherForecastData = new List<WhetherForecast>
            {
                new WhetherForecast()
                {

                  WhetherForecastId = 1, WhetherDescription = "UnitedKingdom", CityId=1,DewPoint="0.0" ,

                }
            }.AsQueryable();

            var mockSetwhetherForecast = new Mock<DbSet<WhetherForecast>>();
            mockSetwhetherForecast.As<IQueryable<WhetherForecast>>().Setup(m => m.Provider).Returns(whetherForecastData.Provider);
            mockSetwhetherForecast.As<IQueryable<WhetherForecast>>().Setup(m => m.Expression).Returns(whetherForecastData.Expression);
            mockSetwhetherForecast.As<IQueryable<WhetherForecast>>().Setup(m => m.ElementType).Returns(whetherForecastData.ElementType);
            mockSetwhetherForecast.As<IQueryable<WhetherForecast>>().Setup(m => m.GetEnumerator()).Returns(() => whetherForecastData.GetEnumerator());

            var mockContext = new Mock<WhetherForecastDBContext>();
            mockContext.Setup(c => c.City).Returns(mockSet.Object);
            mockContext.Setup(c => c.Country).Returns(mockSetCountry.Object);
            mockContext.Setup(c => c.WhetherForecast).Returns(mockSetwhetherForecast.Object);

            var controller = new CityController(mockContext.Object);
            var serachResults = controller.SearchCity("city2");
            Assert.IsTrue(serachResults.City.CityName== "city2");
            
        }
    }
}
