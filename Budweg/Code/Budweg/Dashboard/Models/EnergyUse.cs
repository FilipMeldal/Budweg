using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Models
{
    public class EnergyUse
    {
        public int Id { get; set; }
        public double Watt { get; set; }
        public int? BrakeCaliperFk { get; set; }
    }
}
