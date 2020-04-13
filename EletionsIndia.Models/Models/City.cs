using System;
using System.Collections.Generic;

namespace ElectionsIndia.Models
{
    public partial class City
    {
        public City()
        {
            ElectionArea = new HashSet<ElectionArea>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int DistrictId { get; set; }
        public string StateLanguageName { get; set; }
        public string StateLanguageName_1 { get; set; }
        public string StateLanguageName_2 { get; set; }
        public string StateLanguageName3 { get; set; }
        public string StateLanguagename4 { get; set; }
        public string StateLanguageName5 { get; set; }

        public virtual Districts District { get; set; }
        public virtual ICollection<ElectionArea> ElectionArea { get; set; }
    }
}
