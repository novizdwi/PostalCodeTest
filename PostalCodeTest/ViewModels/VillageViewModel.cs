using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostalCodeTest.Models;

namespace PostalCodeTest.ViewModels
{
    public class VillageViewModel
    {
        public List<Village> VillageList { get; set; }
        public List<SelectListItem> CityList { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int CityId { get; set; }
        public string CityType { get; set; }
        public string CityName { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int Id { get; set; }
        public string VillageName { get; set; }
        public string PostalCode { get; set; }
    }
}
