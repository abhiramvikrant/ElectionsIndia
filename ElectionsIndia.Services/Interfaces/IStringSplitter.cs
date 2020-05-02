using System;
using System.Collections.Generic;
using System.Text;
using ElectionsIndia.Models.ViewModels;

namespace ElectionsIndia.Services.Interfaces
{
   public interface IStringSplitter
    {
       public List<SplitterReturnViewModel> SendTArray(string message);
    }
}
