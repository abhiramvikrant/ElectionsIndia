using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class ElectionWard
    {
        public ElectionWard()
        {
            ElectionBooth = new HashSet<ElectionBooth>();
        }
        [Key]
        public int ElectionWardId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int ElectionAreaId { get; set; }
        public string StateLanguageName { get; set; }
        public string StateLanguageName_1 { get; set; }
        public string StateLanguageName_2 { get; set; }
        public string StateLanguageName_3 { get; set; }
        public string StateLanguagename_4 { get; set; }
        public string StateLanguageName_5 { get; set; }

        public virtual ElectionArea ElectionArea { get; set; }
        public virtual ICollection<ElectionBooth> ElectionBooth { get; set; }
    }
}
