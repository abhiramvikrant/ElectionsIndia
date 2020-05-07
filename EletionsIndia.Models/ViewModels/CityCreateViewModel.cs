using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectionsIndia.Models.ViewModels
{
   public class CityCreateViewModel
    {
        [Key]
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
       
        public bool BelongsToDistrict{ get; set; }

        public int InitialDistrictId { get; set; }
        public string InitialDistrictName { get; set; }
    }
}
