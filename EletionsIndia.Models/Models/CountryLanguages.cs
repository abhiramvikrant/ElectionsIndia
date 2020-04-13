using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class CountryLanguages
    {[Key]
        public int CountryLanguageId { get; set; }
        public int LanguageId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual Countries Country { get; set; }
    }
}
