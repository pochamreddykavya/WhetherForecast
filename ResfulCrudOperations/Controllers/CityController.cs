using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResfulCrudOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResfulCrudOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        CityContext context = null;

        public CityController(CityContext _obj)
        {
            context = _obj;
        }

        [HttpPost]
        public IActionResult AddCity(City city)
        {
            context.City.Add(city);
            context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{cityId}")]
        public IActionResult DeleteCity(int cityId)
        {
            var obj=context.City.Where(x => x.CityId == cityId).FirstOrDefault();
            context.Remove(obj);
            context.SaveChanges();

            return NoContent();
        }

       
        [HttpPut]
        public IActionResult UpdateCity(City city)
        {
            var obj = context.City.Where(x=>x.CityId==city.CityId).FirstOrDefault();
            obj.CityName = city.CityName;
            obj.DateEstablished = city.DateEstablished;
            obj.State = city.State;
            obj.TouristRating = city.TouristRating;
            context.SaveChanges();

            return NoContent();
        }
    }

}
