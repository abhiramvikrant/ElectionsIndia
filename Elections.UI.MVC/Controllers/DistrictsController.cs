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
            if (d is null)
            {
                throw new ArgumentNullException(nameof(d));
            }

            int i = _db.Database.ExecuteSqlRaw($"EXEC InsertDistrict @Name = '{d.Name}', @IsActive = {d.IsActive}, @StateID = {d.StateID}, @CountryID = {d.CountryID}");
                
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