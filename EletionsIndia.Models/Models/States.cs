using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class States
    {
        public States()
        {
            ElectionResult = new HashSet<ElectionResult>();
            Elections = new HashSet<Elections>();
            PoliticalParties = new HashSet<PoliticalParties>();
            StateLanguages = new HashSet<StateLanguages>();
            Voters = new HashSet<Voters>();
        }
        [Key]
        public int StateId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int? CountryId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<ElectionResult> ElectionResult { get; set; }
        public virtual ICollection<Elections> Elections { get; set; }
        public virtual ICollection<PoliticalParties> PoliticalParties { get; set; }
        public virtual ICollection<StateLanguages> StateLanguages { get; set; }
        public virtual ICollection<Voters> Voters { get; set; }
    }
}
