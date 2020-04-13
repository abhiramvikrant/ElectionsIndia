using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectionsIndia.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using ElectionsIndia.Models;
using ElectionsIndia.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading;
using ElectionsIndia.DataAccess;

namespace Elections.UI.MVC.Controllers
{
    public class PoliticalPartyController : Controller
    {
        private readonly IRepository<PoliticalPartyListViewModel> pprepo;
        private readonly ElectionsIndiaContext db;
        private readonly IRepository<Countries> courepo;
        private readonly IRepository<States> staterepo;
        private readonly IRepository<Languages> langrepo;
        private readonly IRepository<PoliticalPartyLanguages> plangrepo;
        private readonly IRepository<PoliticalPartyLanguagesCreateViewModel> crepo;
        private readonly IWebHostEnvironment hostingEnvironment;

        public PoliticalPartyController(IRepository<PoliticalPartyListViewModel> pprepo, ElectionsIndiaContext db,
            IRepository<Countries> courepo, IRepository<States> staterepo, IRepository<Languages> langrepo,
            IRepository<PoliticalPartyLanguages> plangrepo,IRepository<PoliticalPartyLanguagesCreateViewModel> crepo,
            IWebHostEnvironment hostingEnvironment)
        {
            this.pprepo = pprepo;
            this.db = db;
            this.courepo = courepo;
            this.staterepo = staterepo;
            this.langrepo = langrepo;
            this.plangrepo = plangrepo;
            this.crepo = crepo;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var partylist = db.PoliticalPartyListViewModel.FromSqlRaw("EXEC PoliticalPartyList").ToList();
            return View(partylist);
        }

     [HttpGet]
        public IActionResult Create()
        {
            GetDropDOwnList();

            return View();

        }


       

        [HttpPost][ValidateAntiForgeryToken]
        public IActionResult Create(PoliticalPartyLanguagesCreateViewModel pvn)
        {

            Thread.Sleep(1000);
                string uniqueFileName = null;
            string originalpath = null;
           if(pvn.EnglishPartyID == -2) {
                if (pvn.PartyPhoto != null)
                {
                    UploadPhoto(pvn, out uniqueFileName, out originalpath);
                }
            }

                try
                {
                    int i = db.Database.ExecuteSqlInterpolated($"EXEC [PoliticalPartyInsert] @LanguageID = {pvn.LanguageID}, @Name={pvn.Name},@StateID = {pvn.StateID}, @EnglishPartyID = {pvn.EnglishPartyID} , @PhotoPath = {originalpath}");

                    if (i > 0)
                        return RedirectToAction("index");
                }
                catch (Exception ex)
                {

                throw new Exception(ex.InnerException.Message);
            }

            return View(pvn);

        }

        private void UploadPhoto(PoliticalPartyLanguagesCreateViewModel pvn, out string uniqueFileName, out string originalpath)
        {
            string partypath = null;
            partypath = Path.Combine(hostingEnvironment.WebRootPath, "partyimages");
            uniqueFileName = Path.GetFileNameWithoutExtension(pvn.PartyPhoto.FileName) + "_" + Guid.NewGuid().ToString() + Path.GetExtension(pvn.PartyPhoto.FileName);
            string filepath = Path.Combine(partypath, uniqueFileName);
            originalpath = $"/partyimages/{uniqueFileName}";
            try
            {
                using (FileStream fs = new FileStream(filepath, FileMode.Create))
                {
                    pvn.PartyPhoto.CopyTo(fs);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException.Message);
            }
        }

        [HttpGet("{Controller}/Edit/{plangid}")]
        public IActionResult Edit(int plangid)
        {
            GetDropDOwnList();
            var pol = db.PoliticalPartyLanguagesEditViewModel.FromSqlRaw($"EXEC PoliticalPartyByID @partyid = {plangid}").ToList().FirstOrDefault();
            PoliticalPartyLanguagesCreateViewModel pcm = new PoliticalPartyLanguagesCreateViewModel();
            pcm.EnglishPartyID = pol.EnglishPartyID;
                pcm.PoliticalPartyLanguageId = pol.PoliticalPartyLanguageId;
               pcm.StateID = pol.StateID;
            pcm.Name = pol.Name;
            pcm.LanguageId = pol.LanguageId;
            pcm.EnglishPartyID = pol.EnglishPartyID;


            return View(pcm);
        }
        [HttpPost] [ValidateAntiForgeryToken]
        public IActionResult Edit(PoliticalPartyLanguagesCreateViewModel pl)
        {
            string uniqueFileName = null;
            string originalpath = null;
            if (pl.EnglishPartyID == -2) { 
            if (pl.PartyPhoto != null)
            {
                UploadPhoto(pl, out uniqueFileName, out originalpath);
            } }
            PoliticalPartyLanguages p = new PoliticalPartyLanguages();
            if( string.IsNullOrEmpty(originalpath))
            {
                // var pol = plangrepo.GetByID(pl.PoliticalPartyLanguageId);
                p.PartyPhotoPath = pl.OldPhotoPath;
            }
            else
            {
                p.PartyPhotoPath = originalpath;
            }
          
            p.Name = pl.Name;
            p.StateID = pl.StateID;
            p.PoliticalPartyLanguageId = pl.PoliticalPartyLanguageId;
            p.LanguageId = pl.LanguageId;
            p.EnglishPartyID = pl.EnglishPartyID;

            int i = plangrepo.Update(p);
            if (i> 0)
            {
                return RedirectToAction("index");
            }
            return View(pl);

        }

        public IActionResult PoliticalPartyTranslationList()
        {
            return View();
        }
           
            
        

        private void GetDropDOwnList()
        {
            ViewBag.LanguageList = langrepo.GetAll().ToList();
            ViewBag.StateList = staterepo.GetAll().ToList();
            ViewBag.EnglishParty = db.PoliticalPartyLanguages.Where(l => l.EnglishPartyID == -2).Select(p => new { EnglishPartyId = p.PoliticalPartyLanguageId, Name = p.Name }).ToList();

        }

            public IActionResult Delete(int plangid)
            {
                var plangl = plangrepo.GetByID(plangid);
                try
                {
                    int i = plangrepo.Delete(plangl);
                    if (i > 0)
                        return RedirectToAction("index");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", "Unable to delete the Political party");
                    return View(plangl);
                }
            return View(plangl);


        }
        }
   
    }
