using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ElectionsIndia.Models;

namespace ElectionsIndia.Models.ViewModels
{
    public class DistrictListViewModel 
    {
		[Key]
		public int DistrictID { get; set; }
		[DisplayAttribute(Name = "District Name")]
		[Required]
		public string Name { get; set; }
		[Required][DisplayAttribute(Name = "Is Active")]
		public bool IsActive { get; set; }
	
		[Required]
		[DisplayAttribute(Name = "State Name")]
		public int StateID { get; set; }
		[Required]
		[DisplayAttribute(Name = "Country Name")]
		public int CountryID { get; set; }
	public string StateName { get; set; }
        public string CountryName { get; set; }
    }
}
