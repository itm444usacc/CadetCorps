using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadetCorps.Models
{
    public class Awards
    {
        public int Id { get; set; }
        public int AwardsTypesId { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
    }
}