using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectionsIndia.DataAccess;
using ElectionsIndia.Models;
using ElectionsIndia.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ElectionsIndia.Services
{
    public class CastVoteService
    {
        private readonly ElectionsIndiaContext db;

        public CastVoteService(ElectionsIndiaContext db)
        {
            this.db = db;
        }

        public IList<VoteConfigurationViewModel> GetCandidates()
        {
            var candidtaelist = db.VoteConfigurationViewModel.FromSqlInterpolated($"EXEC GetCandidateByBoothId")
                              .ToList<VoteConfigurationViewModel>();
            return candidtaelist;
        }
    }
}
