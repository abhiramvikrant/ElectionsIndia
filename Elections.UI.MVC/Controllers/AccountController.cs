﻿using System;
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

namespace Elections.UI.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> umanager;
        private readonly SignInManager<ApplicationUser> smanager;
        private readonly RoleManager<IdentityRole> rmanager;
        private readonly IMapper mapper;
        

        // GET: Account
        public AccountController(UserManager<ApplicationUser> umanager,SignInManager<ApplicationUser> smanager,  RoleManager<IdentityRole> rmanager, IMapper mapper)
        {
            this.umanager = umanager;
            this.smanager = smanager;
            this.rmanager = rmanager;
            this.mapper = mapper;
           
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

                        ViewBag.Auth = User.Identity.IsAuthenticated;
                    }
                    //return LocalRedirect($"~/account/login?handler=SetIdentity");

                   
                   

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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            try
            {
                var user = mapper.Map<ApplicationUser>(model);
                var result = await umanager.CreateAsync(user).ConfigureAwait(true);
                if (result.Succeeded)
                {
                    var re = await umanager.AddPasswordAsync(user, model.Password).ConfigureAwait(true);
                    return RedirectToAction("index","languages");
                }
            }
            catch(Exception ex)
            {
                return View();
            }
            return View();
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

      

        // POST: Account/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string username)
        {
            try
            {
                // TODO: Add delete logic here
                var user = await umanager.FindByEmailAsync(username).ConfigureAwait(true);
                var result = await umanager.DeleteAsync(user).ConfigureAwait(true);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            var rolelist = rmanager.Roles.ToList();
            RoleCreateViewModels model = new RoleCreateViewModels();
            model.RoleList = rolelist;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoles(string rolename)
        {
            IdentityRole role = new IdentityRole(rolename);
            var result = await rmanager.CreateAsync(role).ConfigureAwait(true);
           return  RedirectToAction("createrole");

        }
    }
}