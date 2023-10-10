using Microsoft.AspNetCore.Mvc;
using ResfulCrudOperations.Models;
using System;
using System.Linq;

namespace ResfulCrudOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        WhetherForecastDBContext context = null;

        public CityController(WhetherForecastDBContext _obj)
        {
            context = _obj;
        }

        [HttpPost]
        public IActionResult AddCity(City city)
        {
            if (city == null)
            {
                return StatusCode(500);
            }
            try
            {
                context.City.Add(city);
                context.SaveChanges();

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{cityId}")]
        public IActionResult DeleteCity(int cityId)
        { 
            if(cityId == 0)
            {
                return null;
            }
            try
            {
                var obj = context.City.Where(x => x.CityId == cityId).FirstOrDefault();
                if(obj==null)
                { 
                    return StatusCode(404);
                }
                context.City.Remove(obj);
                context.SaveChanges();

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public IActionResult UpdateCity(City city)
        {
            if(city==null || city.CityId==0)
            {
                return null;
            }
            try
            {
             var obj = context.City.Where(x => x.CityId == city.CityId).FirstOrDefault();

            if(obj==null)
            {
                return null;
            }
           
                obj.CityName = city.CityName;
                obj.DateEstablished = city.DateEstablished;
                obj.State = city.State;
                obj.TouristRating = city.TouristRating;
                obj.EstimatedPopulation = city.EstimatedPopulation;
                context.SaveChanges();

                return StatusCode(200);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{cityName}")]
        public CityWhetherForecast SearchCity(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
            { return null; }

            var cityWhetherForecast = new CityWhetherForecast();
            try
            {
                var cityInfo = context.City.Where(x => x.CityName == cityName).FirstOrDefault();
                if (cityInfo != null)
                {
                    var countryInfo = context.Country.Where(x => x.CountryId == cityInfo.CountryId).FirstOrDefault();
                    var WhetherForecastInfo = context.WhetherForecast.Where(x => x.CityId == cityInfo.CityId).FirstOrDefault();

                    cityWhetherForecast.City = cityInfo;
                    cityWhetherForecast.Country = countryInfo;
                    cityWhetherForecast.WhetherForecast = WhetherForecastInfo;
                }
            }
            catch(Exception ex)
            {
                cityWhetherForecast.ErrorMessage = ex.Message;
                return cityWhetherForecast;
            }
_logger.LogInformation("Applying coupon {CouponCode}", code);
            return cityWhetherForecast;
        }
        
    }

}
