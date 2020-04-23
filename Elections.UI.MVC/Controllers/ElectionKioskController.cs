using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectionsIndia.Models;
using ElectionsIndia.DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using ElectionsIndia.DataAccess;
using System.Resources;

namespace Elections.UI.MVC.Controllers
{
    public class ElectionKioskController : Controller
    {
        private readonly IRepository<ElectionKiosk> ekrepo;
        private readonly ElectionsIndiaContext db;
        private readonly IRepository<ElectionBooth> boothrepo;
        private readonly ResourceManager resManager;

        public ElectionKioskController(IRepository<ElectionKiosk> ekrepo, ElectionsIndiaContext db,
            IRepository<ElectionBooth> boothrepo, ResourceManager resManager)
        {
            this.ekrepo = ekrepo;
            this.db = db;
            this.boothrepo = boothrepo;
            this.resManager = resManager;
        }
        // GET: ElectionKiosk
        public ActionResult Index()
        {
            var kiosklist = db.ElectionKioskListViewModel.FromSqlRaw("EXEC ElectionKioskList");
            return View(kiosklist);
        }

        // GET: ElectionKiosk/Details/5
     
            private void GetWardList()
        {
            ViewBag.BoothList = boothrepo.GetAll().ToList();
        }

        // GET: ElectionKiosk/Create
        public ActionResult Create()
        {
            GetWardList();
            return View();
        }

        // POST: ElectionKiosk/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ElectionKiosk ek)
        {
            try
            {
                // TODO: Add insert logic here
                int i = ekrepo.Create(ek);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
               
            }
        }

        // GET: ElectionKiosk/Edit/5
        public ActionResult Edit(int kioskid)
        {
            GetWardList();
            var kiosk = ekrepo.GetByID(kioskid);
            return View(kiosk);
        }

        // POST: ElectionKiosk/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ElectionKiosk ek)
        {
            try
            {
                // TODO: Add update logic here
                ekrepo.Update(ek);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
                throw new Exception(ex.Message);
            }
        }

        // GET: ElectionKiosk/Delete/5
        public ActionResult Delete(int kioskid)
        {
            var kiosk = ekrepo.GetByID(kioskid);
            ekrepo.Delete(kiosk);
            return RedirectToAction("index");
         
        }

     
    }
}