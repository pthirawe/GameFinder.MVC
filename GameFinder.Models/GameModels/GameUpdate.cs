using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class GameUpdate
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public int DeveloperId { get; set; }
        public int PublisherId { get; set; }
    }
}
