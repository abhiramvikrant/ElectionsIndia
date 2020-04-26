using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectionsIndia.Models { 
  public  class VW_PoliticalPartiesWithOutNOTA
    {[Key]
        public int PoliticalPartyId { get; set; }
        public string Name { get; set; }
    }
}
