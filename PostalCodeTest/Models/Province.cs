using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PostalCodeTest.Models;

namespace PostalCodeTest.Models
{
    [Table("Province")]
    public class Province
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProvinceName { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
