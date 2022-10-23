using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResfulCrudOperations.Models
{
    public class CityContext: DbContext
    {
        public CityContext(DbContextOptions<CityContext> options) : base(options) { }
        public DbSet<City>City {get; set; }
    }
    public class City
    { 
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
        public int TouristRating { get; set; }
        public DateTime DateEstablished { get; set; }
        public int EstimatedPopulation{ get; set;}
    }
}
