using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models.JoiningModels
{
    public class GameVendorCreate
    {
        [Display(Name = "Game ID")]
        public int GameId { get; set; }
        [Display(Name = "Vendor ID")]
        public int VendorId { get; set; }
        public double Price { get; set; }
        public string Link { get; set; }
    }
}
