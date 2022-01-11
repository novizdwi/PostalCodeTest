using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using PostalCodeTest.Models;
using PostalCodeTest.Services;
using PostalCodeTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList;
using PagedList.Mvc;

namespace PostalCodeTest.Controllers
{
    public class PostalController : Controller
    {
        protected IHttpContextAccessor contextAccessor;
        protected ApplicationDbContext context;
        private Service villageService;
        List<string> FieldFilter = new List<string> { "Provinsi", "Kelurahan" };
        
        public PostalController(IHttpContextAccessor _contextAccessor,
            ApplicationDbContext _context, 
            Service _villageService)
        {
            contextAccessor = _contextAccessor;
            context = _context;
            villageService = _villageService;
        }

        public ViewResult Index(string field, string searchText, int? page)
        {

            int pageNumber = (page ?? 1);
            int recordPerPage = 10;
            int totalPage = villageService.CountTotalPage(recordPerPage);
            List<VillageViewModel> viewModel = villageService.GetAll(field, searchText, pageNumber, recordPerPage);
            ViewBag.Page = pageNumber;
            ViewBag.MaxPage = totalPage;
            ViewBag.field = field;
            ViewBag.searchText = searchText;
            ViewBag.FieldFilter = FieldFilter;

            return View(viewModel.ToPagedList(pageNumber, recordPerPage));
        }

        public async Task<IActionResult> _Edit(int? Id)
        {
            ViewBag.PageName = Id == null ? "Tambah Kelurahan" : "Ubah Kelurahan";
            ViewBag.IsEdit = Id == null ? false : true;
            ViewBag.Id = Id;
            ViewBag.ProvinceList = villageService.GetProvince();

            if (Id == null)
            {
                return View();
            }
            else
            {
                Village village = villageService.FindOne(Id);
                if (village == null)
                {
                    return NotFound();
                }

                return View(village);
            }
        }

        [HttpPost]
        public ActionResult CityJson(string id)
        {
            var recs = villageService.GetCity(id);
            return Json(recs);
        }

        [HttpPost]
        public ActionResult DistrictJson(string id)
        {
            var recs = villageService.GetDistrict(id);
            return Json(recs);
        }

        public async Task<ActionResult> Add(Village model)
        {
            var success = false;
            if (ModelState.IsValid)
            {
                var result = await villageService.Save(model);
                if (result == 1)
                {
                    success = true;
                }
            }

            return Json(new
            {
                Success = success
            });

        }
        public async Task<ActionResult> Edit(string Id, Village model)
        {
            var success = false;
            model.Id = Convert.ToInt32(Id);

            if (ModelState.IsValid)
            {
                var result = await villageService.Edit(model);
                if (result == 1)
                {
                    success = true;
                }
            }

            return Json(new
            {
                Success = success
            });

        }

        public async Task<ActionResult> Delete(int Id)
        {
            var success = false;
            if (ModelState.IsValid)
            {
                var result = await villageService.Delete(Id);
                if (result == 1)
                {
                    success = true;
                }
            }

            return Json(new
            {
                Success = success
            });

        }

    }
}
