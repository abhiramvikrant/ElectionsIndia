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
    public class DistrictsController : Controller
    {
        private readonly IRepository<Districts> _distrepo;
        private readonly ElectionsIndiaContext _db;
        private readonly IRepository<States> _staterepo;
        public DistrictsController(IRepository<Districts> distrepo, ElectionsIndiaContext db, IRepository<States> staterepo)
        {
            _distrepo = distrepo;
            _db = db;
            _staterepo = staterepo;
        }
        public IActionResult Index()
        {
            var distlist = _db.DistrictListViewModel.FromSqlInterpolated($"EXEC DistrictList");
            return View(distlist);
        }
        [HttpGet("{Controller}/Create")]
        public IActionResult Create()
        {
            GetAllDropDownListData();
            return View();
        }
        [HttpPost]
        public IActionResult Create(DistrictListViewModel d)
        {
            int i = _db.Database.ExecuteSqlRaw($"EXEC InsertDistrict @Name = '{d.Name}', @IsActive = {d.IsActive}, @StateID = {d.StateID}, @CountryID = {d.CountryID}, " +
                $"@StateLanguageName = '{d.StateLanguageName}', @StateLanguageName_1 = '{d.StateLanguageName_1}', @StateLanguageName_2 = '{d.StateLanguageName_2}'," +
                $"@StateLanguageName_3 = '{d.StateLanguageName_3}', @StateLanguageName_4 = '{d.StateLanguagename_4}', @StateLanguageName_5 = '{d.StateLanguageName_5}'");
            if (i > 0)
                return RedirectToAction("index");
            return View();
        }
        private void GetAllDropDownListData()
        {
        
            ViewBag.StateList = _staterepo.GetAll().ToList();
            ViewBag.CountryList = _db.Countries.FromSqlRaw("EXEC GetAllCountries").ToList();
            

        }

        public IActionResult Delete(int districtid)
        {
            var dis = _distrepo.GetByID(districtid);
            int i = _distrepo.Delete(dis);
            if (i > 0 )
            {
                return RedirectToAction("index");
            }
            return View();
        }
    }
}