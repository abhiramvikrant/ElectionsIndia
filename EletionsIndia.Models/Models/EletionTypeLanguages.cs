using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class EletionTypeLanguages
    {[Key]
        public int ElectionTypeLanguageId { get; set; }
        public int LanguageId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public int ElectionTypeId { get; set; }

        public virtual Languages Language { get; set; }
    }
}
