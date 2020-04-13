using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionsIndia.Models
{
	public class PoliticalPartyTranslation
	{
		public PoliticalPartyTranslation()
		{

		}
		[Key]
		public int PoliticalPartyTranslationId { get; set; }
		public int PartyId { get; set; }
		public int LanguageId { get; set; }
		public string PartyName { get; set; }

	
	}
}
