using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectionsIndia.Models.ViewModels
{
   public class ElectionWardListByAreaViewModel
    {[Key]
        public int ElectionWardId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public int ElectionAreaId { get; set; }

        public bool BelongsToArea { get; set; }

        public string ElectionArea { get; set; }

        public int InitialAreaId { get; set; }
        public string InitialAreaName { get; set; }
    }
}
