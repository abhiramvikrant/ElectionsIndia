using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class Languages
    {
        public Languages()
        {
            EletionTypeLanguages = new HashSet<EletionTypeLanguages>();
            PoliticalPartyLanguages = new HashSet<PoliticalPartyLanguages>();
        }
        [Key]
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<EletionTypeLanguages> EletionTypeLanguages { get; set; }
        public virtual ICollection<PoliticalPartyLanguages> PoliticalPartyLanguages { get; set; }
    }
}
