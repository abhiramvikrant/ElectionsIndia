using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionsIndia.Models.ViewModels
{
    public class CountryEditViewModel
    {
        public string Country { get; set; }

        public int CountryID { get; set; }

        public int CountryLanguageID { get; set; }

        public string Language { get; set; }

        public int LanguageId { get; set; }

        public string CountryLanguage { get; set;  }
    }
}
