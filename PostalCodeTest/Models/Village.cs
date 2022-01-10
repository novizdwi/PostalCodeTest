using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostalCodeTest.Models
{
    [Table("Village")]
    public class Village
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DistrictId { get; set; }
        public string VillageName { get; set; }
        public string PostalCode { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District Districts { get; set; }
    }
}
