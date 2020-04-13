using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class Voters
    {[Key]
        public int VoterId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int WardId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? LicenseId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual States State { get; set; }
        public virtual License License { get; set; }
    }
}
