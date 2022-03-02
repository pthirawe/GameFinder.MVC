using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class GameListItem
    {
        public int GameId { get; set; }
        public string Title { get; set; } 
        public List<string> Genre { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
    }
}
