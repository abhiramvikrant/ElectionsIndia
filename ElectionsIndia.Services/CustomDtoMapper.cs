using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ElectionsIndia.Models;
using ElectionsIndia.Models.ViewModels;
namespace ElectionsIndia.Services
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            //Add mappings here
            CreateMap<DistrictCreateViewModel, Districts>();
        }
    }
}
