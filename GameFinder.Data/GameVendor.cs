using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Data
{
    public class GameVendor
    {
        [Column(Order = 0), Key, ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        [Column(Order = 1), Key, ForeignKey(nameof(Vendor))]
        public int VendorId { get; set; }
        public double Price { get; set; }
        public string Link { get; set; }

        public virtual Game Game { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
