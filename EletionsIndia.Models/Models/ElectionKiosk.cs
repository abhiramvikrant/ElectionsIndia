using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionsIndia.Models
{
    public class ElectionKiosk
    {
        [Key]
        public int ElectionKioskId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public int ElectionBoothId { get; set; }
    }
}
