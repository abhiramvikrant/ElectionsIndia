using System;
using System.Collections.Generic;
using System.Text;
using ElectionsIndia.Services;
using ElectionsIndia.Models.ViewModels;
using System.Threading.Tasks;

namespace ElectionsIndia.Services.Interfaces
{
   public interface IDistrictService
    {
        Task<List<DistrictCreateViewModel>> GetDistrictsByStateId(int StateId);
    }
}
