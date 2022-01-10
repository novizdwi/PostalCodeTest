using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostalCodeTest.Models
{
    [Table("City")]
    public class City
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public string CityType { get; set; }
        public string CityName { get; set; }

        [ForeignKey("ProvinceId")]
        public virtual Province Provinces { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }

    public enum CityTypeEnum 
    { 
        Kab,
        Kota

    }
}
