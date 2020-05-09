using System;
using System.Collections.Generic;
using System.Text;
using ElectionsIndia.Models.ViewModels;
using System.Threading.Tasks;

namespace ElectionsIndia.Services.Interfaces
{
    public interface IBoothService
    {
        Task<List<ElectionBoothMapViewModel>> GetBoothsByWardId(int WardId);
    }
}
