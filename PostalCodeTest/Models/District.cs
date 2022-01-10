using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostalCodeTest.Models
{
    [Table("District")]
    public class District
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CityId { get; set; }
        public string DistrictName { get; set; }

        [ForeignKey("CityId")]
        public virtual City Provinces { get; set; }
        public virtual ICollection<Village> Villages { get; set; }

    }
}
