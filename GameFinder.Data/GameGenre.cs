using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Data
{
    public class GameGenre
    {
        [Column(Order =0), Key, ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        [Column(Order =1), Key, ForeignKey( nameof(Genre))]
        public int GenreId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
