using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionsIndia.Models
{
    public class CandidateListViewModel
    {
        [Key]
        public int CandidateId { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual Countries Countries { get; set; }
        public virtual States States { get; set; }
        

        public virtual City City { get; set; }
        public virtual  ElectionWard ElectionWard { get; set; }
        public virtual ElectionKiosk ElectionKiosk { get; set; }


        public int CountryId { get; set; }
        public int StateId { get; set; }

        public string District { get; set; }
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
