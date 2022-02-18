using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models.PlatformModels
{
    public class PlatformListItem
    {
        [Display(Name = "Platform ID")]
        public int PlatformId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
    }
}
