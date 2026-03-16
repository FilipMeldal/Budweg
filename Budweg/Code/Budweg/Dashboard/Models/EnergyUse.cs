using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Models
{
    public class EnergyUse
    {
        public int ID { get; set; }
        public double Watt { get; set; }
        public int? BrakeCaliperID { get; set; }
        public int? InspectionID { get; set; }
    }
}
