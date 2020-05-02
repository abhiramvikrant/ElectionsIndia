using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ElectionsIndia.Models.ViewModels;
using ElectionsIndia.Models;
using ElectionsIndia.DataAccess.UserFields;



namespace ElectionsIndia.DataAccess
{
    public partial class ElectionsIndiaContext : IdentityDbContext<ApplicationUser>
    { 
        public ElectionsIndiaContext()
        {
            
        }

        public ElectionsIndiaContext(DbContextOptions<ElectionsIndiaContext> options)
            : base(options)
        {
        }
          public virtual DbSet<AreaLanguages> AreaLanguages { get; set; }
        public virtual DbSet<AreaTypeLanguages> AreaTypeLanguages { get; set; }
        public virtual DbSet<AreaTypes> AreaTypes { get; set; }

        public virtual DbSet<StateListViewModel> StateListViewModel { get; set; }

        public virtual DbSet<CountryListViewModel> CountryListViewModel { get; set; }

        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<CandidateLanguages> CandidateLanguages { get; set; }
        public virtual DbSet<CandidateLicenses> CandidateLicenses { get; set; }
        public virtual DbSet<Candidates> Candidates { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<CountryLanguages> CountryLanguages { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<ElectionArea> ElectionArea { get; set; }
        public virtual DbSet<ElectionBooth> ElectionBooth { get; set; }
        public virtual DbSet<ElectionResult> ElectionResult { get; set; }
        public virtual DbSet<ElectionType> ElectionType { get; set; }
        public virtual DbSet<ElectionWard> ElectionWard { get; set; }
        public virtual DbSet<Elections> Elections { get; set; }
        public virtual DbSet<EletionTypeLanguages> EletionTypeLanguages { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<License> License { get; set; }
        public virtual DbSet<PoliticalParties> PoliticalParties { get; set; }
        public virtual DbSet<PoliticalPartyLanguages> PoliticalPartyLanguages { get; set; }
        public virtual DbSet<StateLanguages> StateLanguages { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<Voters> Voters { get; set; }

        public virtual DbSet<ElectionKiosk> ElectionKiosk { get; set; }



        public virtual DbSet<AreaListViewModel> AreaListViewModel { get; set; }
        public virtual DbSet<StatesEditViewModel> StatesEditViewModel { get; set; }

        public virtual DbSet<DistrictListViewModel> DistrictListViewModel { get; set; }
        public virtual DbSet<CityListViewModels> CityListViewModels { get; set; }
        public virtual DbSet<ElectionWardListViewModel> ElectionWardListViewModel { get; set; }
        public virtual DbSet<ElectionBoothListViewModel> ElectionBoothListViewModel { get; set; }

        public virtual DbSet<ElectionKioskListViewModel> ElectionKioskListViewModel { get; set; }
        public virtual DbSet<PoliticalPartyListViewModel> PoliticalPartyListViewModel { get; set; }

        public virtual DbSet<StateCountryViewModel> StateCountryViewModel { get; set; }

        //public virtual DbSet<PoliticalPartyTranslationListViewModel> PoliticalPartyTranslationListViewModel { get; set; }

        public virtual DbSet<PoliticalPartyTranslation> PoliticalPartyTranslation { get; set; }

        public virtual DbSet<PoliticalPartyLanguagesEditViewModel> PoliticalPartyLanguagesEditViewModel { get; set; }

        public virtual DbSet<VoteConfiguration> VoteConfiguration { get; set; }

        public virtual DbSet<VoteConfigurationViewModel> VoteConfigurationViewModel { get; set; }

        public virtual DbSet<VoteResult> VoteResult { get; set; }
        public virtual DbSet<VW_PoliticalPartiesWithOutNOTA> VW_PoliticalPartiesWithOutNOTA { get; set; }

        public virtual DbSet<VotingResultViewModel> VotingResultViewModel { get; set; }

        public virtual DbSet<VW_CityWithActive> VW_CityWithActive { get; set; }

        public virtual DbSet<VW_DsitrictsWithActive> VW_DsitrictsWithActive { get; set; }

        public virtual DbSet<DistrictCreateViewModel> DistrictCreateViewModel { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
