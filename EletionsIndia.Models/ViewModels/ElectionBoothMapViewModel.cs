using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectionsIndia.Models.ViewModels
{
  public  class ElectionBoothMapViewModel
    {
        [Key]
        public int ElectionBoothId { get; set; }
        public string Name { get; set; }
        public bool IsActvie { get; set; }

        public int ElectionWardId { get; set; }

        public bool BelongsToWard { get; set; }

        public string ElectionWard { get; set; }

        public int InitialWardId { get; set; }
        public string InitialWardName { get; set; }
    }
}
