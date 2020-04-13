using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class ElectionBooth
    {
     [Key]
        public int ElectionBoothId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int ElectionWardId { get; set; }

        public virtual ElectionWard ElectionWard { get; set; }
    }
}
