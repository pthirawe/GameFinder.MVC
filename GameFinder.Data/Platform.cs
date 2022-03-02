using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Data
{
    public class Platform
    {
        [Key]
        public int PlatformId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Medium { get; set; }
        [Required]
        public DateTime LaunchDate { get; set; }
        public DateTime? DiscontinueDate { get; set; }
    }
}
