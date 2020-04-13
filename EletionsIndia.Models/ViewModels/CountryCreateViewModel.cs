using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectionsIndia.Models;
//using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models.ViewModels
{
    public class CountryCreateViewModel
    {
        //public virtual SelectListItem CountryLanguages { get; set; }
        
        [Required]
        [StringLength(100,ErrorMessage ="String length should be lesser than 100 characters")]
        public string Name { get; set; }

      [Display(Name ="Is Active")]
        public bool IsActive { get; set; }
        
        public int CountryID { get; set; }

        public int LanguageId { get; set; }

        public int EnglishCountryID { get; set; }

        public int CountryLanguageID { get; set; }

        //public  List<Languages> LangList { get; set; }
    }
}
