using System;
using System.Collections.Generic;
using System.Text;
using ElectionsIndia.DataAccess;
using ElectionsIndia.Models.ViewModels;
using ElectionsIndia.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ElectionsIndia.Services.Interfaces;


namespace ElectionsIndia.Services
{
   public class DistrictService : IDistrictService 
    {
        private readonly ElectionsIndiaContext db;

        public DistrictService(ElectionsIndiaContext db)
        {
            this.db = db;
        }

        public async Task<List<DistrictCreateViewModel>> GetDistrictsByStateId(int StateId)
        {
            try
            {
                var districtList = await db.DistrictCreateViewModel
                               .FromSqlInterpolated($"EXEC DisrtrictListByStateId @StateId= {StateId}")
                               .ToListAsync<DistrictCreateViewModel>();
                if (districtList is null)
                {
                    throw new Exception
                        ("districtList is NULL from DistrictService's GetDistrictsByStateId method");
                }

                return districtList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }
    }
}
