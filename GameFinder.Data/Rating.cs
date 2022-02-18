using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Data
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        [Required, ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public Guid Author { get; set; }
        public string AuthorName { get; set; }
        public string Review { get; set; }
        [Required, Range(0,10)]
        public double VisualsScore { get; set; }
        [Required, Range(0, 10)]
        public double GameplayScore { get; set; }
        [Required, Range(0, 10)]
        public double SoundScore { get; set; }
        public double OverallScore
        {
            get
            {
                return (VisualsScore+GameplayScore+SoundScore)/3;
            }
        }

        public virtual Game Game { get; set; }
    }
}
