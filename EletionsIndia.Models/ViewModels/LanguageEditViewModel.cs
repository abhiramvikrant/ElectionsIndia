using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionsIndia.Models.ViewModels
{
    public class LanguageEditViewModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public int LanguageID { get; set; }
    }
}
