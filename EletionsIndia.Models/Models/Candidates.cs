using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class Candidates
    {
        public Candidates()
        {
            CandidateLicenses = new HashSet<CandidateLicenses>();
            ElectionResult = new HashSet<ElectionResult>();
        }
        [Key]
        public int CandidateId { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int AreaId { get; set; }
        public int WardId { get; set; }
        public int LanguageId { get; set; }
        public DateTime DateOfbirth { get; set; }
        public string MobileNumber { get; set; }
        public bool HasCriminalRecords { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public decimal PropertyValue { get; set; }
        public int? PoliticalPartyId { get; set; }
        public string Education { get; set; }

        public virtual Areas Area { get; set; }
        public virtual ICollection<CandidateLicenses> CandidateLicenses { get; set; }
        public virtual ICollection<ElectionResult> ElectionResult { get; set; }
    }
}
