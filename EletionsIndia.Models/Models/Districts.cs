using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class Districts
    {
        public Districts()
        {
            City = new HashSet<City>();
        }
        [Key]
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int StateId { get; set; }
        public int? CountryId { get; set; }
       public virtual ICollection<City> City { get; set; }
    }
}
