using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Data
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}
