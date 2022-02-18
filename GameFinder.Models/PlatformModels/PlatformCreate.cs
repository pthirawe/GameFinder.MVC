using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models.PlatformModels
{
    public class PlatformCreate
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Medium { get; set; }
        [Display(Name = "Launch Date")]
        public DateTime LaunchDate { get; set; }
        [Display(Name = "Discontinue Date")]
        public DateTime DiscontinueDate { get; set; }
    }
}
