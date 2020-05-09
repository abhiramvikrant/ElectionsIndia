using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ElectionsIndia.DataAccess;
using ElectionsIndia.Models.ViewModels;
using ElectionsIndia.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ElectionsIndia.Services
{
    public class WardService : IWardService
    {
        private readonly ElectionsIndiaContext db;

        public WardService(ElectionsIndiaContext db)
        {
            this.db = db;
        }

        public async Task<List<ElectionWardListByAreaViewModel>> GetWardByAreaId(int AreaId)
        {
            var wardList = await db.ElectionWardListByAreaViewModel.FromSqlInterpolated($"EXEC ElectionWardByAreaId @AreaId={AreaId}")
                .ToListAsync<ElectionWardListByAreaViewModel>();
            if (wardList != null)
            {
                return wardList;
            }
            else
            {
                throw new Exception("Ward List is null");
            }

        }
    }
}
