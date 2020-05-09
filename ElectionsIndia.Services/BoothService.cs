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
    public class BoothService : IBoothService
    {
        private readonly ElectionsIndiaContext db;

        public BoothService(ElectionsIndiaContext db)
        {
            this.db = db;
        }
        public Task<List<ElectionBoothMapViewModel>> GetBoothsByWardId(int WardId)
        {
            var boothList = db.ElectionBoothMapViewModel.FromSqlInterpolated($"EXEC ElectionBoothByWardId @WardId = {WardId}").
                            ToListAsync<ElectionBoothMapViewModel>();
            if(boothList != null)
            {
                return boothList;
            }
            else
            {
                throw new Exception("boothList is null");
            }
        }
    }
}
