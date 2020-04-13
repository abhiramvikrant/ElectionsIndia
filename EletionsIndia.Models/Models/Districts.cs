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
        public string StateLanguageName { get; set; }
        public string StateLanguageName1 { get; set; }
        public string StateLanguageName2 { get; set; }
        public string StateLanguageName3 { get; set; }
        public string StateLanguagename4 { get; set; }
        public string StateLanguageName5 { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
