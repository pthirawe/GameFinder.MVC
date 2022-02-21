﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Data
{
    public class Feature
    {
        [Key]
        public int FeatureId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
