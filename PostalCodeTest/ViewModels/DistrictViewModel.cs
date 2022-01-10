using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostalCodeTest.Models;

namespace PostalCodeTest.ViewModels
{
    public class DistrictViewModel
    {
        public List<District> DistrictList { get; set; }
        public List<CityDropDownList> CityList { get; set; }
        public int Id { get; set; }
        public int CityId { get; set; }
        public string DistrictName { get; set; }
    }
}
