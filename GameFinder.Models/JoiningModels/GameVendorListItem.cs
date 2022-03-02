using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models.JoiningModels
{
    public class GameVendorListItem
    {
        [Display(Name ="Game ID")]
        public int GameId { get; set; }
        public string Title { get; set; }
        [Display(Name = "Vendor ID")]
        public int VendorId { get; set; }
        [Display(Name = "Vendor")]
        public string VendorName { get; set; }
    }
}
