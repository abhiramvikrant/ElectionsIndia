using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class ElectionType
    {
        public ElectionType()
        {
            Elections = new HashSet<Elections>();
        }
        [Key]
        public int ElectionTypeId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CountryId { get; set; }

        public virtual ICollection<Elections> Elections { get; set; }
    }
}
