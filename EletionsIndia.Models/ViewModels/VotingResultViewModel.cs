using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EletionsIndia.Models.ViewModels
{
   public class VotingResultViewModel
    {[Key]
        public string Name { get; set; }
        public string ShortName { get; set; }
      

        public int Votes { get; set; }
    }
}
