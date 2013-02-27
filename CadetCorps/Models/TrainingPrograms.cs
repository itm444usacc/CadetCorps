using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadetCorps.Models
{
    public class TrainingPrograms
    {
        public int Id { get; set; }
        public int Completed { get; set; }
        public int TrainingProgramsTypesId { get; set; }
        public int TrainingPlansId { get; set; }
        public int TrainingProgramsFormatsId { get; set; }
    }
}