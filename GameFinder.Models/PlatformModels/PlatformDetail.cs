using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models.PlatformModels
{
    public class PlatformDetail
    {
        public int PlatformId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Medium { get; set; }
        public DateTime LaunchDate { get; set; }
        public DateTime? DiscontinueDate { get; set; }
    }
}
