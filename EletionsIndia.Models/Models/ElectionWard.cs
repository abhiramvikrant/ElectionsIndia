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
        public string StateLanguageName1 { get; set; }
        public string StateLanguageName2 { get; set; }
        public string StateLanguageName3 { get; set; }
        public string StateLanguagename4 { get; set; }
        public string StateLanguageName5 { get; set; }

        public virtual ElectionArea ElectionArea { get; set; }
        public virtual ICollection<ElectionBooth> ElectionBooth { get; set; }
    }
}
