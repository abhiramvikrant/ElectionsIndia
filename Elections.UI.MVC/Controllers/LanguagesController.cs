using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElectionsIndia.Models;
using ElectionsIndia.Models.ViewModels;
using ElectionsIndia.DataAccess;
using ElectionsIndia.DataAccess.Repository;

using Microsoft.AspNetCore.Authorization;

namespace Elections.UI.MVC.Controllers
{
    public class LanguagesController : Controller
    {
        private IRepository<Languages> _languagerepo;
        private ElectionsIndiaContext _db;


        public LanguagesController(IRepository<Languages> languagerepo, ElectionsIndiaContext db)
        {
            _languagerepo = languagerepo;
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()

        {
            var lang = _languagerepo.GetAll();
            return View(lang);

        }

        private List<Languages> CheckExists(string langname)
        {

            var retlang = _db.Languages.Where(s => s.Name == langname).ToList();

            return retlang;

        }


        [HttpGet("{Controller}/Create")]

        public IActionResult Create()

        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Languages lang)
        {
            if (lang is null)
            {
                throw new ArgumentNullException(nameof(lang));
            }

            try
            {
                var checklang = CheckExists(lang.Name);
                if (checklang.Count > 0)
                {
                    ViewBag.Message = $"Language {lang.Name} already exists.";
                    return View(lang);
                }

                int ret = _languagerepo.Create(lang);
                if (ret > 0)
                    return RedirectToAction("index");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return new JsonResult($"Error happened: {ex.InnerException.Message} ");
            }

            return View();

            //    ViewBag.Message = $"Language {lang.Name} created successfully ";
            //return View(lang);

        }


        [HttpGet("{Controller}/Edit/{id?}")]
        public IActionResult Edit(int id)
        { var lng = _languagerepo.GetByID(id);
            LanguageEditViewModel levm = new LanguageEditViewModel();
            levm.Name = lng.Name;
            levm.IsActive = lng.IsActive;
            levm.LanguageID = lng.LanguageId;
            return View(levm);
        }
        [HttpPost]
        public IActionResult Edit(Languages t)
        {
            int i = _languagerepo.Update(t);
            if (i > 0)
            {
                return RedirectToAction("index");
            }
            return View(t);
        }


        public IActionResult Delete(int id)
        {
            var languageToDelete = _languagerepo.GetByID(id);
#pragma warning disable CA1304 // Specify CultureInfo
            if (languageToDelete.Name.ToLower() != "english")
#pragma warning restore CA1304 // Specify CultureInfo
            {
                int i = _languagerepo.Delete(languageToDelete);

                if (i > 0)
                {
                    return RedirectToAction("index");
                }
            }
            else
            {
                ViewBag.Message = "English is not allowed to be deleted";
            }

            return View();

        }

    
    }
}