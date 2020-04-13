using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class PoliticalParties
    {[Key]
        public int PoliticalPartyId { get; set; }
        public string Name { get; set; }
        public int ShortName { get; set; }


        public bool IsActive { get; set; }
    }
}
