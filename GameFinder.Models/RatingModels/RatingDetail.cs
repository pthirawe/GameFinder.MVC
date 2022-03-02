using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models.RatingModels
{
    public class RatingDetail
    {
        [Display(Name = "Rating ID")]
        public int RatingId { get; set; }
        public Guid AuthorId { get; set; }
        public string Author { get; set; }
        [Display(Name = "Game ID")]
        public int GameId { get; set; }
        [Display(Name = "Game")]
        public string GameName { get; set; }
        public string Review { get; set; }
        [Display(Name = "Visual Score")]
        public double VisualScore { get; set; }
        [Display(Name = "Gameplay Score")]
        public double GameplayScore { get; set; }
        [Display(Name = "Audio Score")]
        public double SoundScore { get; set; }
        [Display(Name = "Overall Score")]
        public double OverallScore { get; set; }

    }
}
