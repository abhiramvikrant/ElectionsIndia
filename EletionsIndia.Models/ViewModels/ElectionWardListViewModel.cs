﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionsIndia.Models.ViewModels
{
    public class ElectionWardListViewModel
    {
        [Key]
        public int ElectionWardId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int ElectionAreaId { get; set; }
        public string StateLanguageName { get; set; }
        public string StateLanguageName_1 { get; set; }
        public string StateLanguageName_2 { get; set; }
        public string StateLanguageName_3 { get; set; }
        public string StateLanguagename_4 { get; set; }
        public string StateLanguageName_5 { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public string DistrictName { get; set; }

        public string CityName { get; set; }

        public string AreaName { get; set; }

    }
}
