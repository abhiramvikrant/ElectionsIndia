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
using ElectionsIndia.Services.Interfaces;

namespace Elections.UI.MVC.Controllers
{
    public class ElectionWardController : Controller
    {
        private readonly IRepository<ElectionWardListViewModel> ewardrepo;
        private readonly ElectionsIndiaContext db;
        private readonly IRepository<ElectionWard> ewrepo;
        private readonly IRepository<ElectionArea> arerepo;
        private readonly IWardService wardService;
        private readonly IRepository<ElectionWard> wardRepo;

        public ElectionWardController(IRepository<ElectionWardListViewModel> ewardrepo, ElectionsIndiaContext db, IRepository<ElectionWard> ewrepo,
            IRepository<ElectionArea> arerepo, IWardService wardService,IRepository<ElectionWard> wardRepo)
        {
            this.ewardrepo = ewardrepo;
            this.db = db;
            this.ewrepo = ewrepo;
            this.arerepo = arerepo;
            this.wardService = wardService;
            this.wardRepo = wardRepo;
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
            GetAreaList();
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
            GetAreaList();
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

        private void GetAreaList()
        {
            ViewBag.AreaList = arerepo.GetAll().ToList();
        }

        [HttpGet]
        public async Task<IActionResult> MapWards(int AreaId, string AreaName)
        {
            var wardList = await wardService.GetWardByAreaId(AreaId).ConfigureAwait(true);
            foreach (var item in wardList)
            {
                item.InitialAreaId = AreaId;
                item.InitialAreaName = AreaName;
            }

            SetViewBags(AreaId, AreaName);
            if (wardList is null)
                throw new Exception("wardList is null");
            return View(wardList);
        }

        private void SetViewBags(int Id, string Name)
        {
            ViewBag.WardId = Id;
            ViewBag.WardName = Name;
        }

        [HttpPost]
        public IActionResult MapWards(IList<ElectionWardListByAreaViewModel> model)
        {
            var iAreaId = model[0].InitialAreaId;
            var iAreaName = model[0].InitialAreaName;
            SetViewBags(iAreaId, iAreaName);
            List<string> messages = new List<string>();
            for (int i = 0; i < model.Count; i++)
            {
                var ward = wardRepo.GetByID(model[i].ElectionWardId);
                if (model[i].BelongsToArea == true && model[i].ElectionAreaId == -1)
                {
                    ward.ElectionAreaId = iAreaId;
                    var result = wardRepo.Update(ward);
                    WriteResults(ref messages, ward, result);
                }
                else if (model[i].BelongsToArea == false && model[i].ElectionAreaId == iAreaId)
                {
                    ward.ElectionAreaId = null;
                    var result = wardRepo.Update(ward);
                    WriteResults(ref messages, ward, result);

                }
            }

            return RedirectToAction("MapWards", new { areaid = iAreaId, areaname = iAreaName });

        }

        private static void WriteResults(ref List<string> messages, ElectionWard c, int result)
        {
            if (result > 0)
            {
                messages.Add($"{c.Name} updated with {c.ElectionWardId} wardid");
            }
            else
            {
                messages.Add($"Error Occured");
            }
        }
    }
}