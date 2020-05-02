using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectionsIndia.Models.ViewModels
{
  public  class DistrictCreateViewModel
    {
        [Key]
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int StateId { get; set; }
        public bool BelongsToState { get; set; }

        public int InitialStateId { get; set; }
        public string InitialStateName { get; set; }
    }
}
