using System;
using System.Collections.Generic;
using System.Text;
using Dashboard.Models;

namespace Dashboard.ViewModels
{
    public class InspectionViewModel 
    {
        private Inspection _inspection;

        public int Id { get { return _inspection.Id; } set {_inspection.Id = value; } }
        public DateTime Date { get { return _inspection.Date; }set { _inspection.Date = value; } }
        public double Milestone { get { return _inspection.Milestone; } set { _inspection.Milestone = value; } }
        public bool MilestoneReached { get { return _inspection.MilestoneReached; } set { _inspection.MilestoneReached = value; } }
        public string Inspector { get { return _inspection.Inspector; } set { _inspection.Inspector = value; } }


        public InspectionViewModel(Inspection inspection)
        {
            _inspection = inspection;
        }
    }
}
