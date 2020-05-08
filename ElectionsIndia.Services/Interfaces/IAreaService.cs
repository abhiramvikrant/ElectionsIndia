using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectionsIndia.Services.Interfaces
{
   public interface IAreaService
    {
        Task<List<Models.ViewModels.AreaListCreateViewModel>> GetAreaByCityId(int CityId);
    }
}
