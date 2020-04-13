using System;
using System.Collections.Generic;

namespace ElectionsIndia.Models
{
    public partial class CandidateLanguages
    {
        public int CandidateLanguagesId { get; set; }
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int LanguageId { get; set; }
        public DateTime DateOfbirth { get; set; }
        public string MobileNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Education { get; set; }
    }
}
