using System;
using System.Collections.Generic;

namespace ResfulCrudOperations.Models
{
    public partial class WhetherForecast
    {
        public int WhetherForecastId { get; set; }
        public int? CityId { get; set; }
        public string WhetherDescription { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public string DewPoint { get; set; }
        public string Uv { get; set; }
        public string Visibility { get; set; }

        public virtual City City { get; set; }
    }
}
