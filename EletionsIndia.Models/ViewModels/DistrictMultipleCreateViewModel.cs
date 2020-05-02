using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectionsIndia.Models.ViewModels
{
  public  class DistrictMultipleCreateViewModel
    {
        [Required]
        [Display(Name = "Multiple Districts")]
        public string MultipleDistricts { get; set; }

        public int InitialStateId { get; set; }
        public string InitialStateName { get; set; }
    }
}
