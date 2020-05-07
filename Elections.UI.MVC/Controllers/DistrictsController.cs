using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ElectionsIndia.Models;
using ElectionsIndia.DataAccess.Repository;
using ElectionsIndia.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using ElectionsIndia.DataAccess;
using ElectionsIndia.Services;
using ElectionsIndia.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Elections.UI.MVC.Controllers
{
    public class DistrictsController : Controller
    {
        private readonly IRepository<Districts> _distrepo;
        private readonly ElectionsIndiaContext _db;
        private readonly IRepository<States> _staterepo;
        private readonly IDistrictService districtService;
        private readonly IStringSplitter strSplitter;

        public DistrictsController(IRepository<Districts> distrepo,
            ElectionsIndiaContext db, IRepository<States> staterepo,
            IDistrictService districtService,IStringSplitter strSplitter)
        {
            _distrepo = distrepo;
            _db = db;
            _staterepo = staterepo;
            this.districtService = districtService;
            this.strSplitter = strSplitter;
        }
        public IActionResult Index()
        {
            var distlist = _db.DistrictListViewModel.FromSqlInterpolated($"EXEC DistrictList");
            return View(distlist);
        }


        #region MultipleDstrict
        [HttpGet]
        public IActionResult MultipleDistricts(int StateId, string StateName)
        {
            SetViewBag(StateId, StateName);
            return View();
        }

        private void SetViewBag(int StateId, string StateName)
        {
            ViewBag.InitialStateId = StateId;
            ViewBag.InitialStateName = StateName;
        }

        [HttpPost]
        public IActionResult MultipleDistricts(DistrictMultipleCreateViewModel model)
        {

            var districtlist = strSplitter.SendTArray(model.MultipleDistricts);
  
          
            foreach (var item in districtlist)
            {
              
                var dis = new Districts();
                dis.Name = item.Name;

                dis.IsActive = item.IsActive;
                dis.StateId = model.InitialStateId;
                int result = _distrepo.Create(dis);


            }

            return RedirectToAction("MapDistricts", new { StateId = model.InitialStateId, StateName = model.InitialStateName });

        }
        #endregion
        #region Map Districts
        [HttpGet]
        public async Task<IActionResult> MapDistricts(int StateId, string StateName)
        {
            SetViewBag(StateId, StateName);
            var disList = await districtService.GetDistrictsByStateId(StateId).ConfigureAwait(true);
            foreach (var item in disList)
            {
                item.InitialStateId = StateId;
                item.InitialStateName = StateName;

            }
            return View(disList);

        }

        [HttpPost]
        public IActionResult MapDistricts(IList<DistrictCreateViewModel> model)
        {
            var sid = model[0].InitialStateId;
            var stateName = model[0].InitialStateName;
            List<string> messages = new List<string>();
            for (int i = 0; i < model.Count; i++)
            {
                var dist = _distrepo.GetByID(model[i].DistrictId);
                if (model[i].BelongsToState == true && model[i].StateId == -1)
                {
                    dist.StateId = sid;
                    var result = _distrepo.Update(dist);
                    WriteResults(ref messages, dist, result);
                }
                else if (model[i].BelongsToState == false && model[i].StateId == sid)
                {
                    dist.StateId = null;
                    var result = _distrepo.Update(dist);
                    WriteResults(ref messages, dist, result);

                }
            }

            return RedirectToAction("MapDistricts", new { stateid = sid, stateName = stateName });
        } 
     

        private static void WriteResults(ref List<string> messages, Districts dist, int result)
        {
            if (result > 0)
            {
                messages.Add($"{dist.Name} updated with {dist.StateId} StateId");
            }
            else
            {
                messages.Add($"Error Occured");
            }
        }
        #endregion
        #region Create
        [HttpGet("{Controller}/Create")]
        public IActionResult Create()
        {
            GetAllDropDownListData();
            return View();
        }

        [HttpPost]
        public IActionResult Create(DistrictListViewModel d)
        {
            if (d is null)
            {
                throw new ArgumentNullException(nameof(d));
            }

            int i = _db.Database.ExecuteSqlRaw($"EXEC InsertDistrict @Name = '{d.Name}', @IsActive = {d.IsActive}, @StateID = {d.StateID}");

            if (i > 0)
                return RedirectToAction("index");
            return View();
        } 
        #endregion
        private void GetAllDropDownListData()
        {
        
            ViewBag.StateList = _staterepo.GetAll().ToList();
            //ViewBag.CountryList = _db.Countries.FromSqlRaw("EXEC GetAllCountries").ToList();
            

        }

        public IActionResult Delete(int districtid)
        {
            var dis = _distrepo.GetByID(districtid);
            int i = _distrepo.Delete(dis);
            if (i > 0 )
            {
                return RedirectToAction("index");
            }
            return View();
        }
    }
}