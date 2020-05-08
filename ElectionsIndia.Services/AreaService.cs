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
   public class AreaService : IAreaService{
        private readonly ElectionsIndiaContext db;

        public AreaService(ElectionsIndiaContext db)
        {
            this.db = db;
        }

        public async Task<List<Models.ViewModels.AreaListCreateViewModel>> GetAreaByCityId(int CityId)
        {
            var areas = await db.AreaListCreateViewModel.FromSqlInterpolated($"EXEC ElectionAreaByCityId @CityId={CityId}")
                .ToListAsync<AreaListCreateViewModel>();
            if(areas != null)
            {
                return areas; 
            }
            else
            {
                throw new Exception("Area List is null");
            }

        }
    }
}
