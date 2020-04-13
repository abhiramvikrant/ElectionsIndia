using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class AreaLanguages
    {[Key]
        public int AreaLanguageId { get; set; }
        public int LanguageId { get; set; }
        public int AreaId { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }

        public virtual Areas Area { get; set; }
    }
}
