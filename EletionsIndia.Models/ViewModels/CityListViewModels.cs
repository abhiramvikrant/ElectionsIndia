﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionsIndia.Models.ViewModels
{
    public class CityListViewModels
    {
     [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int DistrictId { get; set; }

        public string StateName { get; set; }
         public string DistrictName { get; set; }
    }
}
