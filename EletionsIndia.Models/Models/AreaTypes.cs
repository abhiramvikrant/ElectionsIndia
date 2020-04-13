using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class AreaTypes
    {
        public AreaTypes()
        {
            AreaTypeLanguages = new HashSet<AreaTypeLanguages>();
        }
        [Key]
        public int AreaTypeId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string AreaTypeUniqueId { get; set; }

        public virtual ICollection<AreaTypeLanguages> AreaTypeLanguages { get; set; }
    }
}
