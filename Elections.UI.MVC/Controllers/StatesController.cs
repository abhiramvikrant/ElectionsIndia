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
using System.Globalization;

namespace Elections.UI.MVC.Controllers
{
    public class StatesController : Controller
    {
        private readonly IRepository<States> _staterepo;
        private readonly ElectionsIndiaContext _db;
        private readonly IRepository<Countries> _courepo;
        private readonly IRepository<Languages> _langrepo;
        private readonly IRepository<StateLanguages> _slangrepo;



        public StatesController(IRepository<States> staterepo, ElectionsIndiaContext db, IRepository<Countries> courepo, IRepository<Languages> langrepo, IRepository<StateLanguages> slangrepo)
        {
            _staterepo = staterepo;
            _db = db;
            _courepo = courepo;
            _langrepo = langrepo;
            _slangrepo = slangrepo;
        }
        [HttpGet("{Controller}/Index")]
        public IActionResult Index()
        {
            List<StateListViewModel> statelist = GetAllStates();
            return View(statelist);
        }

        private List<StateListViewModel> GetAllStates()
        {
            var r = _staterepo.GetAll().ToList();
            // use as no tracking otherwise, the data will be duplicated in the StatelistViewModel
            return _db.StateListViewModel.FromSqlRaw("EXEC GetAllStatesWithLanguages").AsNoTracking().ToList(); }

        [HttpGet("{Controller}/Create")]
        public IActionResult Create()
        {
            GetAllDropDownListData();

            return View();
        }

        private void GetAllDropDownListData()
        {
            ViewBag.LanguageList = _langrepo.GetAll().ToList();
            ViewBag.StateList = _staterepo.GetAll().ToList();
            ViewBag.CountryList = _db.Countries.FromSqlRaw("EXEC GetAllCountries").ToList();
        }

        [HttpPost]
        public IActionResult Create(StatesCreateViewModels cm)
        {
            if (cm is null)
            {
                throw new ArgumentNullException(nameof(cm));
            }

            int i = _db.Database.ExecuteSqlRaw($"EXEC InsertStates @Name='{cm.State}', @IsActive = {cm.IsActive}, @CountryID = {cm.CountryId}, @LanguageID = {cm.LanguageID}, @StateID = {cm.StateId}");

            if (i > 0)
                return RedirectToAction("Index");

            return View();

        }
        [HttpGet("{Controller}/Edit/{stateid}/{slangid}")]
        public IActionResult Edit(int stateid, int slangid)
        {
            GetAllDropDownListData();
            if (stateid > 0 )
            {
                var data = _staterepo.GetByID(stateid);
                StatesEditViewModel s = new StatesEditViewModel();
                s.CountryID = data.CountryId;
                s.Language = "English";
                s.StateName = data.Name;
                s.IsActive = data.IsActive;
                s.StateEnglishID = data.StateId;
                s.LanguageID = _langrepo.GetAll().Where( m => m.Name.ToUpperInvariant() == "ENGLISH").ToList()[0].LanguageId;
                s.CountryEnglishID = data.CountryId;s.StateLanguagesID = 0;
                return View(s);
            }
            else if(slangid > 0)
            {
                var slangdata = _db.StatesEditViewModel.FromSqlInterpolated($"exec StateLanguagesByID @statelanguageid={slangid}").ToList()[0];
                return View(slangdata);

            }

            return View();
        }

        [HttpPost("{Controller}/Edit/{stateid}/{slangid}")]
        public IActionResult Edit(StatesEditViewModel sem)
        {
            if (sem is null)
            {
                throw new ArgumentNullException(nameof(sem));
            }

            if (sem.StateLanguagesID > 0)
                return ForStateLanguagesUpdate(sem);
            else if (sem.StateID > 0)            
                return ForStateUpdateSave(sem);

            return View();

        }

        private IActionResult ForStateUpdateSave(StatesEditViewModel sem)
        {
            States s = new States();
            s.StateId = sem.StateID;
            s.Name = sem.StateName;
            s.IsActive = sem.IsActive;
            s.CountryId = sem.CountryID;
            int i = _staterepo.Update(s);
            if (i > 0)
                return RedirectToAction("index");
            return View();
        }

        private IActionResult ForStateLanguagesUpdate(StatesEditViewModel sem)
        {
            StateLanguages sl = new StateLanguages();
            sl.StateLanguagesId = sem.StateLanguagesID;
            sl.LanguageId = sem.LanguageID;
            sl.CountryId = sem.CountryEnglishID;
            sl.Name = sem.StateName;
            sl.IsActive = sem.IsActive;
            sl.StateId = sem.StateEnglishID;
            int i = _slangrepo.Update(sl);
            if (i > 0)
            {
                return RedirectToAction("index");
            }
            return View();
        }

        public IActionResult Delete(int stateid, int slang)
        {
            int i = 0;
            if (slang > 0)
            {
                var slanguages = _slangrepo.GetByID(slang);
                i = _slangrepo.Delete(slanguages);
                
            }
            else if(stateid > 0)
            {
                var s = _staterepo.GetByID(stateid);
                i = _staterepo.Delete(s);
            }
            if( i > 0 )
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}