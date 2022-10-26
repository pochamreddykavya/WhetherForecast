using System;
using System.Collections.Generic;

namespace ResfulCrudOperations.Models
{
    public partial class City
    {
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
        public int? TouristRating { get; set; }
        public DateTime? DateEstablished { get; set; }
        public string EstimatedPopulation { get; set; }
    }
}
