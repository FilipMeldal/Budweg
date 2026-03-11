using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Models
{
    public class Inspection
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Milestone { get; set; }
        public bool MilestoneReached { get; set; }
        public string Inspector { get; set; }
    }
}
