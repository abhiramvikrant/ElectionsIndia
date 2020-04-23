using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EletionsIndia.Models.ViewModels;
using AutoMapper;
using ElectionsIndia.Models;
using ElectionsIndia.DataAccess.Repository;
using System.Globalization;

namespace Elections.UI.MVC.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IRepository<Candidates> canrepo;

        public CandidatesController(IMapper mapper, IRepository<Candidates> canrepo)
        {
            this.mapper = mapper;
            this.canrepo = canrepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CandidateCreateViewModel model)
        {
            var objCandidate = mapper.Map<Candidates>(model);
            int result = canrepo.Create(objCandidate);
            if (result > 0)
            {
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(string candidateid)
        {
            var objCandidate = canrepo.GetByID(int.Parse((candidateid), CultureInfo.InvariantCulture));
            return View(objCandidate);
        }

        [HttpPost]
        public IActionResult Edit(Candidates model)
        {
            int result = canrepo.Update(model);
            if(result > 0)
            {
                return RedirectToAction("index");
            }
            return View();
        }

        public IActionResult Delete(string candidateid)
        {
            int canid = int.Parse(candidateid, CultureInfo.InvariantCulture);
            var objCan = canrepo.GetByID(canid);
            int result = canrepo.Delete(objCan);
                if (result > 0)
            {
                return RedirectToAction("index");
            }
            return View();
        }
    }
}