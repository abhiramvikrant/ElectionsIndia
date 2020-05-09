using Microsoft.Extensions.DependencyInjection;

using ElectionsIndia.DataAccess;
using ElectionsIndia.Services.Interfaces;

namespace ElectionsIndia.Services
{
   public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDbClass(this IServiceCollection services)
        {
            services.AddTransient<ElectionsIndiaContext, ElectionsIndiaContext>();
            services.AddTransient<IDistrictService, DistrictService>();
            services.AddTransient<IStringSplitter, StringSpltter>();
            services.AddTransient<ICityService, CityServices>();
            services.AddTransient<IAreaService, AreaService>();
            services.AddTransient<IWardService, WardService>();
            services.AddTransient<IBoothService, BoothService>();
            services.AddTransient<IKioskService, KioskService>();
            return services;
        }
    }
}
