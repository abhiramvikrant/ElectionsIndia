using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectionsIndia.Models
{
    public class VW_DsitrictsWithActive
    {
        [Key]
        public int DistrictId { get; set; }

        public string Name { get; set; }
    }
}
