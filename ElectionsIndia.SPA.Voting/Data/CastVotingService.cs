using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectionsIndia.DataAccess;
using ElectionsIndia.Models;
using ElectionsIndia.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ElectionsIndia.SPA.Voting.Data
{
    public class CastVotingService
    {
        private readonly ElectionsIndiaContext db;

        public CastVotingService(ElectionsIndiaContext db )
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
