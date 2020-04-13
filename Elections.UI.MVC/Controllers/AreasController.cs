using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ElectionsIndia.DataAccess.Repository;
using ElectionsIndia.Models;
using ElectionsIndia.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using ElectionsIndia.DataAccess;

namespace Elections.UI.MVC.Controllers
{
    public class AreasController : Controller
    {
        private readonly IRepository<AreaListViewModel> _alistrepo;
        private readonly IRepository<States> _staterepo;
        private readonly IRepository<Languages> _langrepo;
        private readonly IRepository<Countries> _courepo;
        private readonly IRepository<City> city;
        private readonly IRepository<ElectionArea> earepo;
        

        private readonly ElectionsIndiaContext _db;
        public AreasController(IRepository<AreaListViewModel> alistrepo, ElectionsIndiaContext db, IRepository<States> staterepo, IRepository<Languages> langrepo, IRepository<Countries> courepo, IRepository<City> city, IRepository<ElectionArea> earepo)
        {
            _alistrepo = alistrepo;
            _db = db;
            _langrepo = langrepo;
            _staterepo = staterepo;
            _courepo = courepo;
            this.city = city;
            this.earepo = earepo;
           
        }
        public IActionResult Index()
        {
            var alist = _db.AreaListViewModel.FromSqlInterpolated($"EXEC ElectionAreaList");
            return View(alist);
        }
        [HttpGet("{Controller}/Create")]
        public IActionResult Create()
        {
            GetAllDropDownListData();
            return View();
        }

        [HttpPost]
        public IActionResult  Create(ElectionArea ea)
        {
            int i = earepo.Create(ea);
            if (i>0)
            {
                return RedirectToAction("index");
            }


            return View(ea);
        }

        [HttpGet]
        public IActionResult Edit(int electionareaid)
        {
            var area = earepo.GetByID(electionareaid);
            GetAllDropDownListData();
            return View(area);
        }

        [HttpPost]
        public IActionResult Edit(ElectionArea ea)
        {
            try
            {
                int i = earepo.Update(ea);
                if(i>0)
                {
                    return RedirectToAction("index");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(ea);
        }

        public IActionResult Delete(int electionareaid)
        {
            var area = earepo.GetByID(electionareaid);
            int i = earepo.Delete(area);
            if (i>0)
            {
                return RedirectToAction("index");
            }
            return View(area);
        }
        private void GetAllDropDownListData()
        {
            
            ViewBag.CityList = city.GetAll().ToList();
 
         
        }
    }
}