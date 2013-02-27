using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadetCorps.Models
{
    public class Evaluations
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }
        public string Comments { get; set; }
        public int ResultGo { get; set; }
        public int MembersId { get; set; }
        public int AwardsId { get; set; }
    }
}