using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadetCorps.Models
{
    public class TrainingPlans
    {
        public int Id { get; set; }
        public IEnumerable<TrainingPrograms> Plan { get; set; }
        public string Description { get; set; }
    }
}