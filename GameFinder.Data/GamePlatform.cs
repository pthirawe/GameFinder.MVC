using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Data
{
    public class GamePlatform
    {
        [Column(Order = 0), Key, ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        [Column(Order = 1), Key, ForeignKey(nameof(Platform))]
        public int PlatformId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Platform Platform { get; set; }
    }
}
