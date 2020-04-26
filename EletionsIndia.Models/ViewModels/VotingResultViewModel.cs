using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectionsIndia.Models.ViewModels
{
   public class VotingResultViewModel
    {[Key]
        public string Name { get; set; }
        public string ShortName { get; set; }
      

        public int Votes { get; set; }

        public string CandidateName { get; set; }
    }
}
