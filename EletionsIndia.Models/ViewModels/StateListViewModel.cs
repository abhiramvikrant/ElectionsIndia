using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectionsIndia.Models;

using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models.ViewModels
{
    public class StateListViewModel
    {
        [Key]
        public int StateLanguagesID { get; set; }
        public string StateName { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public int LanguageID { get; set; }
        public string CountryName { get; set; }
        public string LanguageName { get; set; }


    }
}
