using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionsIndia.Models.ViewModels
{
   public class StateCountryViewModel
    {
        public bool BelongsToCountry { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }

        public string Country { get; set; }

        public string State { get; set; }
    }
}
