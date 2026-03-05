using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Models
{
    public class EnergyUse
    {
        public int EnergyId { get; set; }
        public double Watt { get; set; }
        public int? CaliperIDFk { get; set; }
        public int? InspectionID { get; set; }
    }
}
