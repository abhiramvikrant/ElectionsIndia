using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ElectionsIndia.DataAccess.UserFields;
using ElectionsIndia.Models;

using EletionsIndia.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Elections.UI.MVC
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
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
