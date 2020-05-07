using ElectionsIndia.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectionsIndia.Services.Interfaces
{
   public interface ICityService
    {
        Task<List<CityCreateViewModel>> GetCityByDistrictId(int DistrictId);
    }
}
