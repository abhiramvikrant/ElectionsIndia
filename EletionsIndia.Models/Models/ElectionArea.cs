using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class ElectionArea
    {
        public ElectionArea()
        {
            ElectionWard = new HashSet<ElectionWard>();
        }
        [Key]
        public int ElectionAreaId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int CityId { get; set; }
        public string StateLanguageName { get; set; }
        public string StateLanguageName_1 { get; set; }
        public string StateLanguageName_2 { get; set; }
        public string StateLanguageName_3 { get; set; }
        public string StateLanguagename_4 { get; set; }
        public string StateLanguageName_5 { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<ElectionWard> ElectionWard { get; set; }
    }
}
