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
using ElectionsIndia.Services;
using ElectionsIndia.Services.Interfaces;

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
        private readonly IAreaService areaService;
        private readonly IRepository<ElectionArea> areaRepo;
        private readonly IStringSplitter strSplitter;
        private readonly ElectionsIndiaContext _db;
        public AreasController(IRepository<AreaListViewModel> alistrepo, ElectionsIndiaContext db, IRepository<States> staterepo, IRepository<Languages> langrepo, IRepository<Countries> courepo, IRepository<City> city, IRepository<ElectionArea> earepo
            ,IAreaService areaService, IRepository<ElectionArea> areaRepo, IStringSplitter strSplitter)
        {
            _alistrepo = alistrepo;
            _db = db;
            _langrepo = langrepo;
            _staterepo = staterepo;
            _courepo = courepo;
            this.city = city;
            this.earepo = earepo;
            this.areaService = areaService;
            this.areaRepo = areaRepo;
            this.strSplitter = strSplitter;
        }
        public IActionResult Index()
        {
            var alist = _db.AreaListViewModel.FromSqlInterpolated($"EXEC ElectionAreaList");
            return View(alist);
        }
        #region Create
        [HttpGet("{Controller}/Create")]
        public IActionResult Create()
        {
            GetAllDropDownListData();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ElectionArea ea)
        {
            int i = earepo.Create(ea);
            if (i > 0)
            {
                return RedirectToAction("index");
            }


            return View(ea);
        }
        #endregion

        #region Edit
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
                if (i > 0)
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

        #endregion
        #region Delete
        public IActionResult Delete(int electionareaid)
        {
            var area = earepo.GetByID(electionareaid);
            int i = earepo.Delete(area);
            if (i > 0)
            {
                return RedirectToAction("index");
            }
            return View(area);
        }
        #endregion


        #region UtilityMethods
        private void GetAllDropDownListData()
        {

            ViewBag.CityList = city.GetAll().ToList();


        }
        #endregion

       [HttpGet]
       public async Task<IActionResult> MapAreas(int CityId, string CityName)
        {
            var areaList = await areaService.GetAreaByCityId(CityId).ConfigureAwait(true);
            foreach (var item in areaList)
            {
                item.InitialCityId = CityId;
                item.InitialCityName = CityName;
            }

            SetViewBags(CityId, CityName);

            return View(areaList);
        }

        [HttpPost]
        public IActionResult MapAreas(IList<AreaListCreateViewModel> model)
        {
            var iAreaId = model[0].InitialCityId;
            var iAreaName = model[0].InitialCityName;
            SetViewBags(iAreaId, iAreaName);
            List<string> messages = new List<string>();
            for (int i = 0; i < model.Count; i++)
            { 
                var area = areaRepo.GetByID(model[i].ElectionAreaId);
                if (model[i].BelongsToCity == true && model[i].CityId == -1)
                {
                    area.CityId = iAreaId;
                    var result = areaRepo.Update(area);
                    WriteResults(ref messages, area, result);
                }
                else if (model[i].BelongsToCity == false && model[i].CityId == iAreaId)
                {
                    area.CityId = null;
                    var result = areaRepo.Update(area);
                    WriteResults(ref messages, area, result);

                }
            }

            return RedirectToAction("MapAreas", new { CityId = iAreaId, CityName = iAreaName });

        }

        private static void WriteResults(ref List<string> messages, ElectionArea c, int result)
        {
            if (result > 0)
            {
                messages.Add($"{c.Name} updated with {c.ElectionAreaId} DistrictId");
            }
            else
            {
                messages.Add($"Error Occured");
            }
        }

        private void SetViewBags(int CityId, string CityName)
        {
            ViewBag.CityId = CityId;
            ViewBag.CityName = CityName;
        }

        [HttpGet]
        public IActionResult MultipleAreas(int CityId, string CityName)
        {
            SetViewBags(CityId, CityName);
            return View();
        }

        [HttpPost]
        public IActionResult MultipleAreas(MultiplAreaViewModel model)
        {
            var areaList = strSplitter.SendTArray(model.MultipleAreas);
            foreach (var item in areaList)
            {
                var newArea = new ElectionArea();
                newArea.IsActive = true;
                newArea.Name = item.Name;
                newArea.CityId = model.CityId;
                int result = areaRepo.Create(newArea);

            }
            return RedirectToAction("MapAreas", new { CityId=model.CityId, CityName = model.CityName });

        }
    }
}