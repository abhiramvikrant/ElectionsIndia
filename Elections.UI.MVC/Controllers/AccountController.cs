using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EletionsIndia.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ElectionsIndia.DataAccess.UserFields;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using ElectionsIndia.Models.ViewModels;
using ElectionsIndia.DataAccess.Repository;
using ElectionsIndia.Models;
using System.Resources;
using System.Globalization;
using System.Security.Principal;

namespace Elections.UI.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> umanager;
        private readonly SignInManager<ApplicationUser> smanager;
        private readonly RoleManager<IdentityRole> rmanager;
        private readonly IMapper mapper;
        private readonly IRepository<Countries> courepo;
        private readonly IRepository<VW_CityWithActive> cityRepo;
        //private readonly ResourceManager resManager;



        // GET: Account
        public AccountController(UserManager<ApplicationUser> umanager, SignInManager<ApplicationUser> smanager,
            RoleManager<IdentityRole> rmanager, IMapper mapper, IRepository<Countries> courepo,
            IRepository<VW_CityWithActive> cityRepo)
        {
            this.umanager = umanager;
            this.smanager = smanager;
            this.rmanager = rmanager;
            this.mapper = mapper;
            this.courepo = courepo;
            this.cityRepo = cityRepo;
            //this.resManager = resManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (ModelState.IsValid)
            {
                var user = mapper.Map<ApplicationUser>(model);
                var result = await smanager.PasswordSignInAsync(model.UserName, model.Password, true, false).ConfigureAwait(true);



                if (result.Succeeded)
                {


                    var u = await smanager.UserManager.FindByEmailAsync(model.UserName).ConfigureAwait(true);

                    var claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.Name, u.UserName));
                    claims.Add(new Claim(ClaimTypes.Email, u.Email));

                    var userIdentity = new ClaimsIdentity("Custom");
                    userIdentity.AddClaims(claims);
                    ClaimsPrincipal uPrincipal = new ClaimsPrincipal(userIdentity);
                    AuthenticationProperties ap = new AuthenticationProperties()
                    {
                        ExpiresUtc = DateTime.UtcNow.AddDays(1),
                        IsPersistent = model.RememberMe,
                        AllowRefresh = false
                    };

                 await smanager.SignInWithClaimsAsync(u, ap, claims).ConfigureAwait(true);
                    var isauth = smanager.IsSignedIn(uPrincipal);

                    ViewBag.Auth = User.Identity.IsAuthenticated;
                }
                


                return RedirectToAction("index", "languages");

    
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await smanager.SignOutAsync().ConfigureAwait(true);
            return RedirectToAction("index", "home");
        }
        // GET: Account/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            UserCreateViewModel model = new UserCreateViewModel();
            try
            {
                GetCountryAndCityList(ref model);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
                throw new Exception(ex.Message);
            }

         
            
        }

        private void GetCountryAndCityList(ref UserCreateViewModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            model.CountryList = courepo.GetAll().Where(s => s.IsActive == true).ToList();
            model.CityList = cityRepo.GetAll().ToList();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            try
            {
                model.Email = model.UserName;
                var user = mapper.Map<ApplicationUser>(model);
                var result = await umanager.CreateAsync(user).ConfigureAwait(true);
                if (result.Succeeded)
                {
                    var re = await umanager.AddPasswordAsync(user, model.Password).ConfigureAwait(true);
                    return RedirectToAction("index", "languages");
                }
                else
                {
                    foreach (var item in result.Errors.ToList())
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    GetCountryAndCityList(ref model);
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
              
            }

        }

       // POST: Account/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                
                //throw new ArgumentException(resManager.GetString("usernamemissing",CultureInfo.CurrentCulture), nameof(username));
            }

            try
            {
                // TODO: Add delete logic here
                var user = await umanager.FindByEmailAsync(username).ConfigureAwait(true);
                var result = await umanager.DeleteAsync(user).ConfigureAwait(true);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
        }



        [HttpGet]
        public async Task<IActionResult> AddUsersToRoles(string RoleId)
        {
            if (string.IsNullOrWhiteSpace(RoleId))
            {
                //throw new ArgumentException(resManager.GetString("roleidmissing",CultureInfo.InvariantCulture), nameof(RoleId));
            }

            var role = rmanager.Roles.Where(r => r.Id == RoleId).FirstOrDefault();
            var userNotInRoles = umanager.Users.ToList();
            List<UsersNotInRolesViewModel> UserNotRoleList = new List<UsersNotInRolesViewModel>();

            foreach (var item in userNotInRoles)
            {
                UserNotRoleList.Add(new UsersNotInRolesViewModel()
                {
                    IsInRole = await umanager.IsInRoleAsync(item, role.Name).ConfigureAwait(true),
                    RoleId = RoleId,
                    UserId = item.Id,
                    UserName = item.UserName
                });
            }

            return View(UserNotRoleList);
        }
        [HttpPost]
        public async Task<IActionResult> AddUsersToRoles(IList<UsersNotInRolesViewModel> models, string RoleId)
        {
            if (models is null)
            {
                throw new ArgumentNullException(nameof(models));
            }

            if (string.IsNullOrEmpty(RoleId))
            {
                //throw new ArgumentException(resManager.GetString("roleidmissing", CultureInfo.InvariantCulture), nameof(RoleId));
            }

            var role = rmanager.Roles.Where(r => r.Id == models[0].RoleId).FirstOrDefault();
            foreach (var item in models)
            {
                var u = await umanager.FindByIdAsync(item.UserId).ConfigureAwait(true);
                if ((item.IsInRole) && await umanager.IsInRoleAsync(u, role.Name).ConfigureAwait(true) == false)
                {//if IsInRole is checked and not in roles. Add the user to roles.
                    var user = await umanager.FindByIdAsync(item.UserId).ConfigureAwait(true);
                    var result = await umanager.AddToRoleAsync(user, role.Name).ConfigureAwait(true);
                }
                else if ((!item.IsInRole) && await umanager.IsInRoleAsync(u, role.Name).ConfigureAwait(true))
                {
                    // If IsInRole is not checked and is in Role. Remove the user frm Role
                    var user = await umanager.FindByIdAsync(item.UserId).ConfigureAwait(true);
                    var result = await umanager.RemoveFromRoleAsync(user, role.Name).ConfigureAwait(true);
                }

            }




            return RedirectToAction("AddUsersToRoles", new { RoleId = role.Id });
        }


       [HttpGet]
        public IActionResult CreateRole()
        {
            return GetRoleList();
        }

        private IActionResult GetRoleList()
        {
            var rolelist = rmanager.Roles.ToList();
            RoleCreateViewModels model = new RoleCreateViewModels();
            model.RoleList = rolelist;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string rolename)
        {
            if (string.IsNullOrWhiteSpace(rolename))
            {
                //throw new ArgumentException(resManager.GetString("rolenamenull", CultureInfo.InvariantCulture), nameof(rolename));

            }

            IdentityRole role = new IdentityRole(rolename);
            var result = await rmanager.CreateAsync(role).ConfigureAwait(true);
            return GetRoleList();
            
        }

    



    }
}