using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectionsIndia.Models.ViewModels
{
    public class ElectionKioskMapViewModel
    {
        [Key]
        public int ElectionKioskId { get; set; }
        public string Name { get; set; }
        public bool IsActvie { get; set; }

        public int ElectionBoothId { get; set; }

        public bool BelongsToBooth { get; set; }

        public string ElectionBooth { get; set; }

        public int InitialBoothId { get; set; }
        public string InitialBoothName { get; set; }
    }
}
