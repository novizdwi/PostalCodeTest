using Microsoft.Extensions.Configuration;
using PostalCodeTest.Models;
using PostalCodeTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostalCodeTest.Services
{
    public class VillageService
    {
        private readonly ApplicationDbContext db;
        protected readonly IConfiguration Configuration;
        public VillageService(ApplicationDbContext context)
        {
            db = context;
        }

        public List<VillageViewModel> GetAll()
        {
            var y = db.Villages.ToList();

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

            return ret.ToList();
        }
    }
}
