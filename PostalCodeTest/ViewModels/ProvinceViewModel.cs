using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostalCodeTest.Models;

namespace PostalCodeTest.ViewModels
{
    public class ProvinceViewModel
    {
        public List<Province> Provinces { get; set; }
        public int Id { get; set; }
        public string ProvinceName { get; set; }
    }
}
