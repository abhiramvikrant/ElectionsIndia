using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectionsIndia.Models
{
    public partial class ElectionResult
    {[Key]
        public int ElectionResultId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int AreaId { get; set; }
        public int WardId { get; set; }
        public int CandidateId { get; set; }
        public int PoliticalPartyId { get; set; }
        public int? UserId { get; set; }
        public int ElectionTypeId { get; set; }
        public DateTime VoteCastedOn { get; set; }

        public virtual Areas Area { get; set; }
        public virtual Candidates Candidate { get; set; }
        public virtual Countries Country { get; set; }
        public virtual States State { get; set; }
    }
}
