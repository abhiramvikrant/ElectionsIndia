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
using ElectionsIndia.Services;
using ElectionsIndia.Services.Interfaces;

namespace Elections.UI.MVC.Controllers
{
    public class CityController : Controller
    {
        private readonly IRepository<City> cityrepo;
        private readonly ElectionsIndiaContext db;
        private readonly IRepository<CityListViewModels> clrepo;
        private readonly IRepository<Districts> disrepo;
        private readonly ICityService cityService;
        private readonly IRepository<City> cityRepo;
        private readonly IStringSplitter strSplitter;

        public CityController(IRepository<City> cityrepo, ElectionsIndiaContext db, 
            IRepository<CityListViewModels> clrepo, IRepository<Districts> disrepo,
            ICityService cityService, IRepository<City> cityRepo, IStringSplitter strSplitter)
        {
            this.cityrepo = cityrepo;
            this.db = db;
            this.clrepo = clrepo;
            this.disrepo = disrepo;
            this.cityService = cityService;
            this.cityRepo = cityRepo;
            this.strSplitter = strSplitter;
        }
        public IActionResult Index()
        {
            var citylist = db.CityListViewModels.FromSqlRaw("Exec CityList").ToList();
            return View(citylist);
        }
        #region Create
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
        #endregion
        #region MapCities
        [HttpPost]
        public IActionResult MapCities(IList<CityCreateViewModel> model)
        {
            var iDistId = model[0].InitialDistrictId;
            var iDistName = model[0].InitialDistrictName;
            List<string> messages = new List<string>();
            for (int i = 0; i < model.Count; i++)
            {
                var city = cityRepo.GetByID(model[i].CityId);
                if (model[i].BelongsToDistrict == true && model[i].DistrictId == -1)
                {
                    city.DistrictId = iDistId;
                    var result = cityRepo.Update(city);
                    WriteResults(ref messages, city, result);
                }
                else if (model[i].BelongsToDistrict == false && model[i].DistrictId == iDistId)
                {
                    city.DistrictId = null;
                    var result = cityRepo.Update(city);
                    WriteResults(ref messages, city, result);

                }
            }

            return RedirectToAction("MapCities", new { DistrictId = iDistId, DistrictName = iDistName });
        }

        [HttpGet]
        public async Task<IActionResult> MapCities(int DistrictId, string DistrictName)
        {
            var cityLists = await cityService.GetCityByDistrictId(DistrictId).ConfigureAwait(true);
            foreach (var item in cityLists)
            {
                item.InitialDistrictId = DistrictId;
                item.InitialDistrictName = DistrictName;
            }
            SetViewBag(DistrictId, DistrictName);
            if (cityLists is null)
            {
                throw new Exception("cityLists is null");
            }

            return View(cityLists);

        }

        private void SetViewBag(int DistrictId, string DistrictName)
        {
            ViewBag.InitialDistrictId = DistrictId;
            ViewBag.InitialDistrictName = DistrictName;
        }

        private static void WriteResults(ref List<string> messages, City c, int result)
        {
            if (result > 0)
            {
                messages.Add($"{c.Name} updated with {c.DistrictId} DistrictId");
            }
            else
            {
                messages.Add($"Error Occured");
            }
        } 
        #endregion
        [HttpGet]
        public IActionResult MultipleCities(int districtid, string districtname)
        {
            SetViewBag(districtid, districtname);
            return View();
        }
        [HttpPost]
        public IActionResult MultipleCities(MultipleCitiesViewModel model)
        {
            var cList = strSplitter.SendTArray(model.CityList);
            foreach (var item in cList)
            {
                var newCity = new City();
                newCity.IsActive = true;
                newCity.Name = item.Name;
                newCity.DistrictId = model.DistrictId;
                int result = cityrepo.Create(newCity);

            }
            return RedirectToAction("MapCities", new { DistrictId = model.DistrictId, DistrictName = model.DistrictName });

        }
    }
}