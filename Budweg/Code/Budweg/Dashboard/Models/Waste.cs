using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Media3D;

namespace Dashboard.Models
{
    public class Waste
    {
        public int WasteID { get; set; }
        public double WasteAmount { get; set; }
        public string Material { get; set; }
        public int? CaliperID { get; set; }
        public int? InspectionID { get; set; }




    }
}
