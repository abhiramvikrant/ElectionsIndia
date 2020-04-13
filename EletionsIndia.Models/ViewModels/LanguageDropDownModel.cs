﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionsIndia.Models.ViewModels
{
    public class LanguageDropDownModel
    {
        [Key]
        public int LanguageID { get; set; }
        public string Name { get; set; }
    }
}
