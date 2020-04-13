using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class License
    {[Key]
        public int LicenseId { get; set; }
        public string Name { get; set; }

        public virtual Voters LicenseNavigation { get; set; }
    }
}
