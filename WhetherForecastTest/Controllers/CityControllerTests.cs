using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using ResfulCrudOperations.Controllers;
using ResfulCrudOperations.Models;

namespace WhetherForecastTest.Controllers
{
    
    [TestFixture]
    public class CityControllerTests
    {
        //[Test]
        //public void AddCity_StateUnderTest_ExpectedBehavior()
        //{
        //    //var mock = new Mock<DbContext>();
        //    //mock.Setup(x => x.Set<>);
        //    WhetherForecastDBContext context = new WhetherForecastDBContext();
        //    City city = new City();
        //    city.CityId = 1;

        //    context.Add(city);
        //    // Arrange
        //    var cityController = new CityController(context);
            
        //    // Act
        //    var result = cityController.AddCity(
        //        city);

        //    // Assert
        //    Assert.True(result);
        //}

        //[Test]
        //public void DeleteCity_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var cityController = new CityController(TODO);
        //    int cityId = 0;

        //    // Act
        //    var result = cityController.DeleteCity(
        //        cityId);

        //    // Assert
        //    Assert.Fail();
        //}

        //[Test]
        //public void UpdateCity_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var cityController = new CityController(TODO);
        //    City city = null;

        //    // Act
        //    var result = cityController.UpdateCity(
        //        city);

        //    // Assert
        //    Assert.Fail();
        //}

        //[Test]
        //public void SearchCity_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var cityController = new CityController(TODO);
        //    string cityName = null;

        //    // Act
        //    var result = cityController.SearchCity(
        //        cityName);

        //    // Assert
        //    Assert.Fail();
        //}

        [Test]
        public void CreateBlog_saves_a_blog_via_context()
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
    }
}
