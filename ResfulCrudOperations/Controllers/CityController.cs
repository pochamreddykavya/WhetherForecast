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
        public bool AddCity(City city)
        {
            context.City.Add(city);
            context.SaveChanges();

            return true;
        }

        [HttpDelete("{cityId}")]
        public IActionResult DeleteCity(int cityId)
        {
            var obj = context.City.Where(x => x.CityId == cityId).FirstOrDefault();
            context.Remove(obj);
            context.SaveChanges();

            return NoContent();
        }


        [HttpPut]
        public IActionResult UpdateCity(City city)
        {
            var obj = context.City.Where(x => x.CityId == city.CityId).FirstOrDefault();
            obj.CityName = city.CityName;
            obj.DateEstablished = city.DateEstablished;
            obj.State = city.State;
            obj.TouristRating = city.TouristRating;
            context.SaveChanges();

            return NoContent();
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
                    var countryInfo = context.Country.Where(x => x.CityId == cityInfo.CityId).FirstOrDefault();
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

            return cityWhetherForecast;
        }
        
    }

}
