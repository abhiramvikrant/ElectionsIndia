using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class CandidateLicenses
    {[Key]
        public int CandidateLicenseId { get; set; }
        public int CandidateId { get; set; }
        public int LicenseId { get; set; }
        public string LicenseUploadUrl { get; set; }

        public virtual Candidates Candidate { get; set; }
    }
}
