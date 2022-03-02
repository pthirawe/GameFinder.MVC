using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        [Required]
        public string Title { get; set; } 
        public string Description { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required, ForeignKey(nameof(Developer))]
        public int DeveloperId { get; set; }
        [Required, ForeignKey(nameof(Publisher))]
        public int PublisherId { get; set; }

        public virtual Developer Developer { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
