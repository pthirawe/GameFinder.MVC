using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class RatingListItem
    {
        public int RatingId { get; set; }
        [Display(Name = "Game")]
        public string GameName { get; set; }
        [Display(Name = "Overall Rating")]
        public double OverallRating { get; set; }

    }
}
