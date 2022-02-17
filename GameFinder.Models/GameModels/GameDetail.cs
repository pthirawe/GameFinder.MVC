using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class GameDetail
    {
        [Display(Name = "Game ID")]
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Developer ID")]
        public int DeveloperId { get; set; }
        public string Developer { get; set; }
        [Display(Name = "Publisher ID")]
        public int PublisherId { get; set; }
        public string Publisher { get; set; }
    }
}
