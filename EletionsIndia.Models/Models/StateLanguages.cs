using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class StateLanguages
    {[Key]
        public int StateLanguagesId { get; set; }
        public int LanguageId { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public bool? IsActive { get; set; }

        public virtual States State { get; set; }
    }
}
