using System;
using System.Collections.Generic;

namespace ResfulCrudOperations.Models
{
    public partial class WhetherForecast
    {
        public int WhetherForecastId { get; set; }
        public int? CityId { get; set; }
        public string WhetherDescription { get; set; }
        public int? Humidity { get; set; }
        public int? DewPoint { get; set; }
        public int? Uv { get; set; }
        public int? Visibility { get; set; }
    }
}
