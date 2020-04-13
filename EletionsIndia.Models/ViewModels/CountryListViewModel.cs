using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ElectionsIndia.Models.ViewModels
{
    public class CountryListViewModel
    {
        [Key]
        public int CountryLanguageID { get; set; }
        public string CountryName { get; set; }
        public int CountryID { get; set; }

        public int LanguageID { get; set; }

        public string LanguageName { get; set; }
        public string CountryLanguageName { get; set; }

        //public SelectList LangList { get; set; }
    }
}
