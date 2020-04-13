using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ElectionsIndia.Models.ViewModels
{
    public class StatesEditViewModel
    {
        [Key]
        public int StateLanguagesID { get; set; }
        public int StateID { get; set; }
        [DisplayAttribute(Name= "State Name")]
        public string StateName { get; set; }
        [DisplayAttribute(Name = "Is Active")]
        public bool IsActive { get; set; }

        public int CountryID { get; set; }

        public string Language { get; set; }

        public int LanguageID { get; set; }

        public int StateEnglishID { get; set; }

        public int CountryEnglishID { get; set; }

       
        public string CountryName { get; set; }

        public string LanguageName { get; set; }


    }
}
