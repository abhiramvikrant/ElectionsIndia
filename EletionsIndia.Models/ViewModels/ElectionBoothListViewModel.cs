using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionsIndia.Models.ViewModels
{
    public class ElectionBoothListViewModel
    {
        [Key]
        public int ElectionBoothId { get; set; }
        public string BoothName { get; set; }
        public bool IsActive { get; set; }
        public int ElectionWardId { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string DistrictName { get; set; }

        public string CityName { get; set; }

        public string AreaName { get; set; }

        public string WardName { get; set; }
    }
}
