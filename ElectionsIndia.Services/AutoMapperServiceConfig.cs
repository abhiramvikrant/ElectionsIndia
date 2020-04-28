using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ElectionsIndia.DataAccess.UserFields;
using ElectionsIndia.Models;
using ElectionsIndia.Models.ViewModels;

namespace ElectionsIndia.Services
{
   public  class AutoMapperServiceConfig: Profile
    {
        public AutoMapperServiceConfig()
        {
            
            CreateMap<VoteConfigurationViewModel, VoteResult>();
            CreateMap<VoteConfiguration, VoteResult>();
            CreateMap<VoteConfigurationCreateViewModel, VoteConfiguration>();
            CreateMap<CandidateCreateViewModel, Candidates>();
            CreateMap<UserCreateViewModel, ApplicationUser>();
            CreateMap<LoginViewModel, ApplicationUser>();
        }
    }
}
