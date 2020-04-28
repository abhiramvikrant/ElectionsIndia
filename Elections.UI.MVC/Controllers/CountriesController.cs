using ElectionsIndia.Models;
using ElectionsIndia.DataAccess.Repository;
using ElectionsIndia.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ElectionsIndia.DataAccess;
using Elections.UI.MVC.Properties;
using System.Resources;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Elections.UI.MVC.Controllers
{
    public class CountriesController : Controller
    {
        private IRepository<Countries> _countryrepo;
        private ElectionsIndiaContext _db;
        private IRepository<Languages> _langrepo;
        private IRepository<CountryLanguages> _countrylang;
        private readonly ResourceManager resManager;
        private readonly IRepository<States> stateRepo;

        public CountriesController(IRepository<Countries> countryrep, ElectionsIndiaContext db, IRepository<Languages> langrepo, IRepository<CountryLanguages> countrylang
            , ResourceManager resManager, IRepository<States> stateRepo)
        {
            _countryrepo = countryrep;
            _db = db;
            _langrepo = langrepo;
            _countrylang = countrylang;
            this.resManager = resManager;
            this.stateRepo = stateRepo;
        }
        public IActionResult Index()
        {
            List<CountryListViewModel> objCountries = GetCountryLanguageList();
            return View(objCountries);
        }

        private List<CountryListViewModel> GetCountryLanguageList()
        {
            return _db.CountryListViewModel.FromSqlRaw("EXEC GetAllCountryByLanguages").ToList();
        }

        [HttpGet("{Controller}/Create")]
        public IActionResult Create()
        {
            List<Languages> langlist = new List<Languages>();
            langlist = _langrepo.GetAll().ToList();
            ViewBag.LangList = langlist;


            List<Countries> englishcountrylist = new List<Countries>();
            englishcountrylist = _countryrepo.GetAll().Where(i => i.IsActive == true).ToList();
            ViewBag.EnglishList = englishcountrylist;

            return View();
        }
        [HttpGet("{Controller}/Edit")]
        public IActionResult Edit(string languagename, string countrylanguagename,  string countryname, int languageid, int clang)
        {
            if (string.IsNullOrEmpty(languagename))
            {
                throw new System.ArgumentException(resManager.GetString("languagenamemissing", CultureInfo.CurrentCulture), nameof(languagename));

            }

            if (string.IsNullOrEmpty(countrylanguagename))
            {
                throw new System.ArgumentException(resManager.GetString("countrylanguagenamemissing", CultureInfo.CurrentCulture),nameof(countrylanguagename));
            }

            if (string.IsNullOrEmpty(countryname))
            {
                throw new System.ArgumentException(resManager.GetString("countrynamemissing",CultureInfo.InvariantCulture), nameof(countryname));
            }

            CountryEditViewModel ced = null;
            if (languagename == "English")
            {
                var clList= GetCountryLanguageList().Where(l => l.LanguageID == languageid && l.CountryName == countryname).ToList()[0];
                ced = new CountryEditViewModel()
                {
                    Country = clList.CountryName,
                    Language = clList.LanguageName,
                    CountryLanguageID = clList.CountryLanguageID,
                    CountryID = clList.CountryID,
                    CountryLanguage = clList.CountryLanguageName
                };
                    }
            else
            {
                var clList = GetCountryLanguageList().Where(l => l.CountryLanguageID == clang).ToList()[0];
                ced = new CountryEditViewModel()
                {
                    Country = clList.CountryLanguageName,
                    Language = clList.LanguageName,
                    CountryLanguageID = clList.CountryLanguageID,
                    CountryID = clList.CountryID,
                   
                };
            }
            return View(ced);
        }

        [HttpPost]
        public IActionResult Edit(CountryEditViewModel cem)
        {
            if (cem is null)
            {
                throw new System.ArgumentNullException(nameof(cem));
            }

            int i;
            if(ModelState.IsValid)
            {              
                if(cem.Language == "English")
                {
                    Countries co = new Countries();
                    co.Name = cem.Country;
                    co.CountryId = cem.CountryID;
                  i =   _countryrepo.Update(co);
                }
                else

                {
                    CountryLanguages cl = new CountryLanguages() { CountryLanguageId = cem.CountryLanguageID, Name = cem.Country, CountryId = cem.CountryID, LanguageId = cem.LanguageId };
                    i = _countrylang.Update(cl);

                }
                if (i > 0)
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public IActionResult MapStatesToCountry(int CountryId)
        {
            try
            {
                var list = _db.StateCountryViewModel.
                    FromSqlInterpolated($"EXEC StateListByCountryId @CountryId={CountryId}").ToList();
                if (list != null && list.Count > 0)                
                return View(list); 
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return View();
            
        }

        [HttpPost]
        public IActionResult MapStatesToCountry(IList<StateCountryViewModel> modelList)
        {
            if (modelList is null)
            {
                throw new System.ArgumentNullException(nameof(modelList));
            }

            try
            {
                for (int i = 0; i < modelList.Count; i++)
                {
                    var item = modelList[i];
                    var clist = stateRepo.GetByID(item.StateId);
                    if (item.BelongsToCountry == true)
                    {
                 
                        if (clist.CountryId != item.CountryId)
                        {
                           var mockState= GetState(item);
                            var result = stateRepo.Update(mockState);
                           
                        }
                    }
                }
                return View();
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

       

        }

        private States  GetState(StateCountryViewModel model)
        {
            var statMock = new States
            {
                StateId = model.StateId,
                Name = model.State,
                CountryId = model.CountryId,
                IsActive = true
            };
            return statMock;
        }

        [HttpPost]
        public IActionResult Create(CountryCreateViewModel c)
        {
            if (c is null)
            {
                throw new System.ArgumentNullException(nameof(c));
            }

            if (ModelState.IsValid)
            {
             
                var langids = _langrepo.GetAll().Where(l => l.Name == "English").ToList();
                
                int englishid = langids[0].LanguageId;
                if(c.LanguageId == englishid)
                {
                    Countries cou = new Countries() { Name = c.Name, IsActive = c.IsActive };
                    int r = _countryrepo.Create(cou);
                    return RedirectToAction("Index");
                }
                else

                {
                    CountryLanguages clangs = new CountryLanguages() { Name = c.Name, LanguageId = c.LanguageId, CountryId = c.EnglishCountryID };
                    int i = _countrylang.Create(clangs);
                    return RedirectToAction("Index");

                }



                


            }
            return View();


        }

    
        public IActionResult Delete(
            string languagename,
            int countryid,
            int clang)
        {
            if(languagename == "English")
            {
                Countries c = new Countries();
                c.CountryId = countryid;
                int i = _countryrepo.Delete(c);
                return RedirectToAction("Index");
            }
            else
            {
                CountryLanguages cl = new CountryLanguages();
                cl.CountryLanguageId = clang;
                int i = _countrylang.Delete(cl);
                return RedirectToAction("Index");


            }
          
        }
    }
}