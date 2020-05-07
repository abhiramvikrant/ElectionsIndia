using System;
using System.Collections.Generic;

namespace ElectionsIndia.Models
{
    public partial class City
    {
        public City()
        {
            
        }

        public int CityId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int? DistrictId { get; set; }


        public virtual Districts District { get; set; }
        public virtual ICollection<ElectionArea> ElectionArea { get; set; }
    }
}
