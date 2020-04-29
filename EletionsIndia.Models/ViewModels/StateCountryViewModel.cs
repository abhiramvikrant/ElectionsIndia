using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectionsIndia.Models.ViewModels
{
   public class StateCountryViewModel
    {[Key]
        public int StateId { get; set; }
        public bool BelongsToCountry { get; set; }
        
        public int CountryId { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public int InitialCountryId { get; set; }

        public string InitialCountryName { get; set; }
    }
}
