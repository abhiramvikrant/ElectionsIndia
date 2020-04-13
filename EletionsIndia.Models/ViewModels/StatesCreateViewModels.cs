using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ElectionsIndia.Models;


namespace ElectionsIndia.Models.ViewModels
{
    public class StatesCreateViewModels
    {
        [Key]
        public int StateId { get; set; }

        public int StateLanguagesID { get; set; }
        [Required]
        public string State { get; set; }
     

        [DisplayAttribute(Name = "Country")]
        public int CountryId { get; set; }
        [DisplayAttribute(Name = "Language")]
        public int LanguageID { get; set; }
        public string Language { get; set; }
        [DisplayAttribute(Name = "Is Active")]
        public bool IsActive { get; set; }
      }
}
