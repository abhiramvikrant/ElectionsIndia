using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class PoliticalPartyLanguages
    {[Key]
        public int PoliticalPartyLanguageId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }          
        public int StateID { get; set; }
        public int EnglishPartyID { get; set; }

      
        public string PartyPhotoPath { get; set; }

        public virtual Languages Language { get; set; }
    }
}
