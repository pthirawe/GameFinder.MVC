using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models.JoiningModels
{
    public class GameVendorUpdate
    {
        public int GameId { get; set; }
        public int VendorId { get; set; }
        public double Price { get; set; }
        public string Link { get; set; }
    }
}
