using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectionsIndia.Models.ViewModels
{
   public class AreaListCreateViewModel
    {[Key]
        public int ElectionAreaId { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public bool BelongsToCity { get; set; }

        public string City { get; set; }

        public int InitialCityId { get; set; }

        public string InitialCityName { get; set; }

        public bool IsActive { get; set; }
    }
}
