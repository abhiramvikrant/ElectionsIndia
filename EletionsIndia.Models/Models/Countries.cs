using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class Countries
    {
        public Countries()
        {
            CountryLanguages = new HashSet<CountryLanguages>();
            ElectionResult = new HashSet<ElectionResult>();
            Elections = new HashSet<Elections>();
            PoliticalParties = new HashSet<PoliticalParties>();
            States = new HashSet<States>();
            Voters = new HashSet<Voters>();
        }
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<CountryLanguages> CountryLanguages { get; set; }
        public virtual ICollection<ElectionResult> ElectionResult { get; set; }
        public virtual ICollection<Elections> Elections { get; set; }
        public virtual ICollection<PoliticalParties> PoliticalParties { get; set; }
        public virtual ICollection<States> States { get; set; }
        public virtual ICollection<Voters> Voters { get; set; }
    }
}
