using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ElectionsIndia.Models;
using ElectionsIndia.DataAccess.Repository;
using ElectionsIndia.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using ElectionsIndia.DataAccess;

namespace Elections.UI.MVC.Controllers
{
    public class CityController : Controller
    {
        private readonly IRepository<City> cityrepo;
        private readonly ElectionsIndiaContext db;
        private readonly IRepository<CityListViewModels> clrepo;
        private readonly IRepository<Districts> disrepo;

        public CityController(IRepository<City> cityrepo, ElectionsIndiaContext db, IRepository<CityListViewModels> clrepo, IRepository<Districts> disrepo)
        {
            this.cityrepo = cityrepo;
            this.db = db;
            this.clrepo = clrepo;
            this.disrepo = disrepo;
        }
        public IActionResult Index()
        {
            var citylist = db.CityListViewModels.FromSqlRaw("Exec CityList").ToList();
            return View(citylist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DistrictList = disrepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(City c)
        {
            int i = cityrepo.Create(c);
            if (i > 0)
                return RedirectToAction("index");
            return View(c);
        }
    }
}