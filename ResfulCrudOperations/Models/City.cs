using System;
using System.Collections.Generic;

namespace ResfulCrudOperations.Models
{
    public partial class City
    {
        public City()
        {
            Country = new HashSet<Country>();
            WhetherForecast = new HashSet<WhetherForecast>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
        public int? TouristRating { get; set; }
        public DateTime? DateEstablished { get; set; }
        public string EstimatedPopulation { get; set; }

        public virtual ICollection<Country> Country { get; set; }
        public virtual ICollection<WhetherForecast> WhetherForecast { get; set; }
    }
}
