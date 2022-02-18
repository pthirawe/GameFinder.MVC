using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models.RatingModels
{
    public class RatingUpdate
    {
        public int GameId { get; set; }
        public string Review { get; set; }
        [Display(Name = "Visual Score")]
        public double VisualScore { get; set; }
        [Display(Name = "Gameplay Score")]
        public double GameplayScore { get; set; }
        [Display(Name = "Audio Score")]
        public double SoundScore { get; set; }
    }
}
