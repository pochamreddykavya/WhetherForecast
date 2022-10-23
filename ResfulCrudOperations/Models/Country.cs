using System;
using System.Collections.Generic;

namespace ResfulCrudOperations.Models
{
    public partial class Country
    {
        public string CountryId { get; set; }
        public string CityId { get; set; }
        public string TwoDigitCountryCode { get; set; }
        public string ThreeDigitCountryCode { get; set; }
    }
}
