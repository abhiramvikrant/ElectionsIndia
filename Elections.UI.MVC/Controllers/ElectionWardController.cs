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
    public class ElectionWardController : Controller
    {
        private readonly IRepository<ElectionWardListViewModel> ewardrepo;
        private readonly ElectionsIndiaContext db;
        private readonly IRepository<ElectionWard> ewrepo;
        private readonly IRepository<ElectionArea> arerepo;

        public ElectionWardController(IRepository<ElectionWardListViewModel> ewardrepo, ElectionsIndiaContext db, IRepository<ElectionWard> ewrepo, IRepository<ElectionArea> arerepo)
        {
            this.ewardrepo = ewardrepo;
            this.db = db;
            this.ewrepo = ewrepo;
            this.arerepo = arerepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var wardlist = db.ElectionWardListViewModel.FromSqlRaw("EXEC ElectionWardList").ToList();
            return View(wardlist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            GetAreList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ElectionWard ew)
        {
            int i = ewrepo.Create(ew);
            if (i > 0)
                return RedirectToAction("index");
            return View();
        }

        [HttpGet("{Controller}/Edit/{electionwardid}")]
        public IActionResult Edit(int electionwardid)
        {
            GetAreList();
            var ew = ewrepo.GetByID(electionwardid);
            return View(ew);
        }

        [HttpPost]
       public IActionResult Edit(ElectionWard ew)
        {
            int i = ewrepo.Update(ew);
            if(i >0)
            {
                return RedirectToAction("index");
            }
            return View(ew);
        }


        public IActionResult Delete(int electionwardid)
        {
            var ward = ewrepo.GetByID(electionwardid);
            int i = ewrepo.Delete(ward);
            if (i > 0)
            {
                return RedirectToAction("index");
            }
            return View(ward);
        }

        private void GetAreList()
        {
            ViewBag.AreaList = arerepo.GetAll().ToList();
        }

    }
}