using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadetCorps.Models
{
    public class ServiceInformationGrades
    {
        public int Id { get; set; }
        public int Active { get; set; }
        public int ServiceInformationGradesTypesId { get; set; }
        public int ServiceInformation { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastModified { get; set; }
        
    }
}