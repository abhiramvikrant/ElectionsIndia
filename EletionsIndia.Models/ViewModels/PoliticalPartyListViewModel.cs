using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionsIndia.Models.ViewModels
{
    public class PoliticalPartyListViewModel
    {
     [Key]   
        public int PoliticalPartyLanguageID { get; set; }

        public string PoliticalPartyName { get; set; }

        public string StateName { get; set; }

        public string LanguageName { get; set; }

        public int LanguageID { get; set; }

        public string PoliticalPartyLanguageName { get; set; }

        public string CountryName { get; set; }

        public string EnglishPartyName { get; set; }

        public int EnglishPartyID { get; set; }

        public int StateID { get; set; }

        public string PartyPhotoPath { get; set; }




    }
}
