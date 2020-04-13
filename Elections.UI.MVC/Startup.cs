using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ElectionsIndia.DataAccess.Repository;
using ElectionsIndia.DataAccess;
using AutoMapper;
using ElectionsIndia.DataAccess.UserFields;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Elections.UI.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
      
            services.AddControllersWithViews();
            //services.AddDbContext<ElectionsIndiaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ElCon")));
            services.AddDbContext<ElectionsIndiaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ElCon")));
            services.AddScoped(typeof(ElectionsIndiaContext), typeof(ElectionsIndiaContext));
            
            services.AddScoped(typeof(UserManager<ApplicationUser>), typeof(UserManager<ApplicationUser>));            
            services.AddScoped(typeof(RoleManager<IdentityRole>), typeof(RoleManager<IdentityRole>));
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(c => c.AddProfile<AutoMapperConfig>(), typeof(Startup));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ElectionsIndiaContext>().AddDefaultTokenProviders();
            //services.AddEntityFrameworkSqlServer();
            services.AddAuthenticationCore();
           
       

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            

            app.UseRouting();
            app.UseAuthentication();
            app.UseRequestLocalization();
     
            app.UseAuthorization();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Languages}/{action=Index}/{id?}");
            });
        }
    }
}
