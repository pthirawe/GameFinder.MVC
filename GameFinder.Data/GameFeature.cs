using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Data
{
    public class GameFeature
    {
        [Column(Order = 0), Key, ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        [Column(Order = 1), Key, ForeignKey(nameof(Feature))]
        public int FeatureId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
