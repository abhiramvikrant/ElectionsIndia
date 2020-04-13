using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class AreaTypeLanguages
    {[Key]
        public int AreaTypeLanguageId { get; set; }
        public int LanguageId { get; set; }
        public int AreaTypeId { get; set; }
        public string Name { get; set; }

        public virtual AreaTypes AreaType { get; set; }
    }
}
