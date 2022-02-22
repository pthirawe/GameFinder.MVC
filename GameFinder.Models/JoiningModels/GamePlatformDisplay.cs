using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models.JoiningModels
{
    public class GamePlatformDisplay
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public int PlatformID { get; set; }
        public string Name { get; set; }
    }
}
