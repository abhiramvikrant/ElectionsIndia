using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class Areas
    {
        public Areas()
        {
            AreaLanguages = new HashSet<AreaLanguages>();
            Candidates = new HashSet<Candidates>();
            ElectionResult = new HashSet<ElectionResult>();
            Elections = new HashSet<Elections>();
        }
        [Key]
        public int AreaId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }

        public virtual ICollection<AreaLanguages> AreaLanguages { get; set; }
        public virtual ICollection<Candidates> Candidates { get; set; }
        public virtual ICollection<ElectionResult> ElectionResult { get; set; }
        public virtual ICollection<Elections> Elections { get; set; }
    }
}
