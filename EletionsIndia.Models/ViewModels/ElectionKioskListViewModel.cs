using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionsIndia.Models.ViewModels
{
    public class ElectionKioskListViewModel
    {
        [Key]
        public int ElectionKioskId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public string BoothName { get; set; }
    }
}
