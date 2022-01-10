using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostalCodeTest.Models;

namespace PostalCodeTest.ViewModels
{
    public class CityViewModel
    {
        public List<City> CitiyList { get; set; }
        public List<SelectListItem> ProvinceList { get; set; }
        public List<SelectListItem> CityTypes { get; set; }
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public string CityType { get; set; }
        public string DistrictName { get; set; }
    }

    public class CityDropDownList 
    {
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public string DistrictName { get; set; }
    }
}
