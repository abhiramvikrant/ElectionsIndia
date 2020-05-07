using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ElectionsIndia.DataAccess;
using ElectionsIndia.Models;
using ElectionsIndia.Models.ViewModels;
using ElectionsIndia.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ElectionsIndia.Services
{
    public class CityServices : ICityService
    {
        private readonly ElectionsIndiaContext db;

        public CityServices(ElectionsIndiaContext db)
        {
            this.db = db;
        }

        public async Task<List<CityCreateViewModel>> GetCityByDistrictId(int DistrictId)
        {
            try
            {

                var cityList = await db.CityCreateViewModel
                               .FromSqlInterpolated($"EXEC CityLisByDistictId @DistrictId= {DistrictId}")
                               .ToListAsync();
                if (cityList is null)
                {
                    throw new Exception
                        ("cityList is NULL");
                }

               
                return cityList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

    }
}
