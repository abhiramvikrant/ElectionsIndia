using ElectionsIndia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionsIndia.Models.ViewModels
{
    public class PoliticalPartyLanguagesEditViewModel
    {
        [Key]
        public int PoliticalPartyLanguageId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public int LanguageID { get; set; }
        public int StateID { get; set; }
        public int EnglishPartyID { get; set; }

        
        public string PartyPhotoPath { get; set; }

        public virtual Languages Language { get; set; }
    }
}
