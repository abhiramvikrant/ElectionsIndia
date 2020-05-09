using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ElectionsIndia.Models.ViewModels;

namespace ElectionsIndia.Services.Interfaces
{
    public interface IWardService
    {
        Task<List<ElectionWardListByAreaViewModel>> GetWardByAreaId(int AreaId);
    }
}
