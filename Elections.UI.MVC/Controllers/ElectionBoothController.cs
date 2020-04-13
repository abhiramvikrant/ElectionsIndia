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
    public class ElectionBoothController : Controller
    {
        private readonly IRepository<ElectionBooth> borepo;
        private readonly ElectionsIndiaContext db;
        private readonly IRepository<ElectionWard> wardrepo;

        public ElectionBoothController(IRepository<ElectionBooth> borepo, ElectionsIndiaContext db, IRepository<ElectionWard> wardrepo)
        {
            this.borepo = borepo;
            this.db = db;
            this.wardrepo = wardrepo;
        }
        // GET: ElectionBooth
        public ActionResult Index()
        {
            var boothlist = db.ElectionBoothListViewModel.FromSqlRaw("EXEC ElectionBoothList").ToList();
            return View(boothlist);
        }

        // GET: ElectionBooth/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ElectionBooth/Create
        public ActionResult Create()
        {
            GetWardList();
            return View();
            
        }

        private void GetWardList()
        {
            ViewBag.WardList = wardrepo.GetAll().ToList();
        }

        // POST: ElectionBooth/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ElectionBooth eb)
        {
            try
            {
                // TODO: Add insert logic here
                int i = borepo.Create(eb);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
           
        }

        // GET: ElectionBooth/Edit/5
        public ActionResult Edit(int boothid)
        {
            GetWardList();
            var boothlist = borepo.GetByID(boothid);
            return View(boothlist);
        }

        // POST: ElectionBooth/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ElectionBooth eb)
        {
            try
            {
                int i = borepo.Update(eb);
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

            

        // POST: ElectionBooth/Delete/5
       
        public ActionResult Delete(int boothid)
        {
            try
            {
                var booth = borepo.GetByID(boothid);
                int i = borepo.Delete(booth);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}