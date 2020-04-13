using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class Elections
    {[Key]
        public int ElectionId { get; set; }
        public int? ElectionTypeId { get; set; }
        public DateTime? ElectionDate { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int WardId { get; set; }
        public int AreaId { get; set; }

        public virtual Areas Area { get; set; }
        public virtual Countries Country { get; set; }
        public virtual ElectionType ElectionType { get; set; }
        public virtual States State { get; set; }
    }
}
