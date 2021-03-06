using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using PostalCodeTest.Models;
using PostalCodeTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostalCodeTest.Services
{
    public class Service
    {
        private readonly ApplicationDbContext db;
        protected readonly IConfiguration Configuration;
        public Service(ApplicationDbContext context)
        {
            db = context;
        }
        public int CountTotalPage(int recordPerPage = 10)
        {
            var ret = db.Villages.Count();
            return ret / recordPerPage;
        }
        public List<SelectListItem> GetProvince() 
        {
            var ret = (from p in db.Provinces
            select new SelectListItem() { 
                Value = p.Id.ToString(),
                Text = p.ProvinceName,
            });
            return ret.ToList();
        }
        public List<SelectListItem> GetCity( string provinceId) 
        {
            var ret = (from p in db.Cities.Where(x=> x.ProvinceId.ToString() == provinceId)
                       select new SelectListItem() { 
                Value = p.Id.ToString(),
                Text = p.CityType+" "+p.CityName,
            });
            return ret.ToList();
        }
        public List<SelectListItem> GetDistrict( string cityId) 
        {
            var ret = (from p in db.Districts.Where(x=> x.CityId.ToString() == cityId)
            select new SelectListItem() { 
                Value = p.Id.ToString(),
                Text = p.DistrictName,
            });
            return ret.ToList();
        }

        public List<VillageViewModel> GetAll(string field, string searchText, int page, int recordPerPage)
        {

            var ret = (from village in db.Villages
                       join district in db.Districts on village.DistrictId equals district.Id
                       join city in db.Cities on district.CityId equals city.Id
                       join province in db.Provinces on city.ProvinceId equals province.Id
                       select new VillageViewModel()
                       {
                           ProvinceId = province.Id,
                           ProvinceName = province.ProvinceName,
                           CityId = city.Id,
                           CityType = city.CityType,
                           CityName = city.CityName,
                           DistrictId = district.Id,
                           DistrictName = district.DistrictName,
                           Id = village.Id,
                           VillageName = village.VillageName,
                           PostalCode = village.PostalCode,
                       });

            if (!string.IsNullOrEmpty(field) && !string.IsNullOrEmpty(searchText))
            {
                if (field == "Provinsi")
                {
                    ret = ret.Where(x => x.ProvinceName.Contains(searchText));
                }
                else 
                {
                    ret = ret.Where(x => x.VillageName.Contains(searchText));
                }
            }

            ret.Skip((page-1)*recordPerPage).Take(recordPerPage);
            return ret.ToList();
        }

        public Village FindOne(int? id = 0)
        {
            return db.Villages.Find(id);

        }
        public async Task<int> Save(Village model)
        {
            try
            {
                var village = new Village()
                {
                    DistrictId = model.DistrictId,
                    VillageName = model.VillageName,
                    PostalCode = model.PostalCode,
                };
                db.Villages.Add(village);
                var success = await db.SaveChangesAsync() > 0;
                if (success)
                {
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> Edit(Village model)
        {
            try
            {                
                var data = db.Villages.Find(model.Id);
                if (data != null)
                {
                    data.DistrictId = model.DistrictId;
                    data.VillageName = model.VillageName;
                    data.PostalCode = model.PostalCode;

                    var success = await db.SaveChangesAsync() > 0;
                    if (success)
                    {
                        return 1;
                    }

                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var del = db.Villages.Find(id);
                if (del != null)
                {
                    db.Villages.Remove(del);
                    var success = await db.SaveChangesAsync() > 0;
                    if (success)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
