using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResfulCrudOperations.Models
{
    public class CityWhetherForecast
    {
        public City City { get; set; }

        public Country Country { get; set; }

        public WhetherForecast WhetherForecast { get; set; }

        public string ErrorMessage { get; set; }
    }
}
