using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EletionsIndia.Models.ViewModels
{
    public class VoteConfigurationCreateViewModel
    {
		[Key]
		public int? VoteConfigurationId { get; set; }
		[Display(Name = "Candidate")]
		[Required(ErrorMessage = "Candidate is required")]
		public int CandidateId { get; set; }
		[Required(ErrorMessage = "Country is required")]
		[Display(Name = "Country")]
		public int CountryId { get; set; }
		[Required(ErrorMessage = "The State field is required")]
		[Display(Name = "State")] 
		public int StateID { get; set; }
		[Required(ErrorMessage = "Dsitrict is required")]
		[Display(Name = "District")]
		public int DistrictId { get; set; }
		[Required(ErrorMessage = "Area is required")]
		[Display(Name = "Area")]
		public int AreaId { get; set; }
		[Required(ErrorMessage = "Ward is required")]
		[Display(Name = "Ward")]
		public int WardId { get; set; }
		[Required(ErrorMessage = "Booth is required")]
		[Display(Name = "Booth")]
		public int BoothId { get; set; }
		[Required(ErrorMessage = "Kiosk is required")]
		[Display(Name = "Kiosk")]
		public int KioskId { get; set; }
		[Required(ErrorMessage = "Election Type is required")]
		[Display(Name = "Election Type")]
		public int ElectionTypeId { get; set; }
		[Required(ErrorMessage = "Political Party is required")]
		[Display(Name = "Political Party")]
		public int PoliticalPartyId { get; set; }

		
		public string CandidateName { get; set; }

		public string PoliticalPartyName { get; set; }

		public string PoliticalPartyShortName { get; set; }

		public IList CountryList { get; set; }
		public IList CandidateList { get; set; } 

		public IList StatesList { get; set; }

		public IList DistrictList { get; set; }

		public IList CityList { get; set; }

		public IList AreaList { get; set; }
		public IList WardList { get; set; }

		public IList BoothList { get; set; }

		public IList KioskList { get; set; }

		public IList PoliticalPartyList { get; set; }

		public IList ElectionTypeList { get; set; }
	}
}
