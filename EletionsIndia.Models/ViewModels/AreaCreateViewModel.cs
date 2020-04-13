using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionsIndia.Models.ViewModels
{
    public class AreaCreateViewModel
    {
     [Key]
        public int ElectionAreaID { get; set; }
        public int CityId { get; set; }

        [DisplayAttribute(Name ="Area Name")][Required]
        public string AreaName { get; set; }

        public bool IsActive { get; set; }
       
        public string StateLanguageName { get; set; }
        public string StateLanguageName_1 { get; set; }
        public string StateLanguageName_2 { get; set; }
        public string StateLanguageName_3 { get; set; }
        public string StateLanguagename_4 { get; set; }
        public string StateLanguageName_5 { get; set; }
    }
}
