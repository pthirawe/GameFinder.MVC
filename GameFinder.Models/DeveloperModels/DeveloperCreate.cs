﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class DeveloperCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}
