using System;
using System.Collections.Generic;

namespace ResfulCrudOperations.Models
{
    public partial class Country
    {
        public int CountryId { get; set; }
        public int? CityId { get; set; }
        public string TwoDigitCountryCode { get; set; }
        public string ThreeDigitCountryCode { get; set; }
        public string CountryName { get; set; }

        public virtual City City { get; set; }
    }
}
