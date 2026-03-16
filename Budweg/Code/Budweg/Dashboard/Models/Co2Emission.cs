using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Models
{
    public class Co2Emission
    {
        public int ID { get; set; }
        public double Weight {  get; set; }
        public int? BrakeCaliperID { get; set; }
        public int? InspectionID { get; set; }
    }
}
