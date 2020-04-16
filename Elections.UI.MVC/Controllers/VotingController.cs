using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ElectionsIndia.DataAccess;
using ElectionsIndia.DataAccess.Repository;
using ElectionsIndia.Models;
using EletionsIndia.Models;
using EletionsIndia.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elections.UI.MVC.Controllers
{
    public class VotingController : Controller
    {
        private readonly IRepository<VoteConfigurationViewModel> vcrepo;
        private readonly IRepository<VoteResult> resrepo;
        private readonly IRepository<VoteConfiguration> crepo;
        private readonly ElectionsIndiaContext db;
        private readonly IMapper mapper;
        private readonly IRepository<Countries> courepo;
        private readonly IRepository<States> strepo;
        private readonly IRepository<VW_DsitrictsWithActive> disrepo;
        private readonly IRepository<City> cirepo;
        private readonly IRepository<Areas> arepo;
        private readonly IRepository<ElectionWard> ewardrepo;
        private readonly IRepository<ElectionBooth> borepo;
        private readonly IRepository<ElectionKiosk> kioskrepo;
        private readonly IRepository<Candidates> carepo;
        private readonly IRepository<PoliticalParties> parepo;
        private readonly IRepository<ElectionType> typerepo;
        private readonly IRepository<VoteConfiguration> confrepo;

        public VotingController(IRepository<VoteConfigurationViewModel> vcrepo,IRepository<VoteResult> resrepo,
            IRepository<VoteConfiguration> crepo, ElectionsIndiaContext db, IMapper mapper,
            IRepository<Countries> courepo, IRepository<States> strepo, IRepository<VW_DsitrictsWithActive> disrepo,
            IRepository<City> cirepo, IRepository<Areas> arepo,IRepository<ElectionWard> ewardrepo,
            IRepository<ElectionBooth> borepo, IRepository<ElectionKiosk> kioskrepo, IRepository<Candidates> carepo
            ,IRepository<PoliticalParties> parepo, IRepository<ElectionType> typerepo,
            IRepository<VoteConfiguration> confrepo)
        {
            this.vcrepo = vcrepo;
            this.resrepo = resrepo;
            this.crepo = crepo;
            this.db = db;
            this.mapper = mapper;
            this.courepo = courepo;
            this.strepo = strepo;
            this.disrepo = disrepo;
            this.cirepo = cirepo;
            this.arepo = arepo;
            this.ewardrepo = ewardrepo;
            this.borepo = borepo;
            this.kioskrepo = kioskrepo;
            this.carepo = carepo;
            this.parepo = parepo;
            this.typerepo = typerepo;
            this.confrepo = confrepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var candidtaelist = db.VoteConfigurationViewModel.FromSqlInterpolated($"EXEC GetCandidateByBoothId")
                               .ToList<VoteConfigurationViewModel>(); 
            return View(candidtaelist);
        }

        [HttpPost]
        public IActionResult CasteVote(string uid)
        {
            var model = crepo.GetAll().Where(s => s.VoteConfigurationUID.ToString() == uid).FirstOrDefault();
            var voteresult = mapper.Map<VoteResult>(model);
            var result = resrepo.Create(voteresult);
         
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            VoteConfigurationCreateViewModel model = new VoteConfigurationCreateViewModel();
             GetAllLists(ref model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VoteConfigurationCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var castVC = mapper.Map<VoteConfiguration>(model);
                castVC.VoteConfigurationUID = Guid.NewGuid();
                int result = confrepo.Create(castVC);
                if (result > 0)
                {
                    return RedirectToAction("create");
                }
            }
            return View();
        }
            private void GetAllLists(ref VoteConfigurationCreateViewModel model)
        {
            try
            {
                model.CountryList = courepo.GetAll().Where(s => s.IsActive == true).ToList();
                model.CandidateList = carepo.GetAll().Where(s => s.IsActive == true).ToList();
                model.StatesList = strepo.GetAll().Where(s => s.IsActive == true).ToList();
                model.DistrictList = disrepo.GetAll().ToList();
                model.CityList = cirepo.GetAll().Where(s => s.IsActive == true).ToList();
                model.AreaList = arepo.GetAll().Where(s => s.IsActive == true).ToList();
                model.WardList = ewardrepo.GetAll().Where(s => s.IsActive == true).ToList();
                model.BoothList = borepo.GetAll().Where(s => s.IsActive == true).ToList();
                model.KioskList = kioskrepo.GetAll().Where(s => s.IsActive == true).ToList();
                model.PoliticalPartyList = db.VW_PoliticalPartiesWithOutNOTA.ToList();
                model.ElectionTypeList = typerepo.GetAll().Where(s => s.IsActive == true).ToList();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult VotingResult()
        {
            var result = db.VotingResultViewModel.FromSqlInterpolated($"EXEC VoteResultByPlotiticalPartyId").ToList();
            return View(result);
        }

    }
}