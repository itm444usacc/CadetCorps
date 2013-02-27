﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadetCorps.Models
{
    public class Activities
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ActivityName { get; set; }
        public string Description { get; set; } 
    }
}