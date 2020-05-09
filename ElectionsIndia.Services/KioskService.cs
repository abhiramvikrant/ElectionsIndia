using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ElectionsIndia.Models.ViewModels;
using ElectionsIndia.Services.Interfaces;
using ElectionsIndia.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ElectionsIndia.Services
{
    public class KioskService : IKioskService
    {
        private readonly ElectionsIndiaContext db;

        public KioskService(ElectionsIndiaContext db)
        {
            this.db = db;
        }
        public Task<List<ElectionKioskMapViewModel>> GetKioskByBoothId(int BoothId)
        {
            var kioskList = db.ElectionKioskMapViewModel.FromSqlInterpolated($"EXEC ElectionKioskByBoothId @BoothId = {BoothId}").
                            ToListAsync<ElectionKioskMapViewModel>();

            if(kioskList != null)
            {
                return kioskList;
            }
            else
            {
                throw new Exception("kioskList is null");
            }
        }
    }
}
