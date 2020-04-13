using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectionsIndia.Models
{
    public class VoteResult
    {[Key]
		public int VoteResultId { get; set; }
		public int CandidateId { get; set; }
		public int CountryId { get; set; }
		public int StateId { get; set; }
		public int DistrictId { get; set; }
		public int AreaiD { get; set; }
		public int WardId { get; set; }
		public int BoothId { get; set; }
		public int KioskId { get; set; }
		public int ElectionTypeId { get; set; }


		public Guid? VoteResultUID { get; set; }

		public int PoliticalPartyId { get; set; }
	}
}
