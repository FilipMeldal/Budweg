using Dashboard.Commands;
using Dashboard.Models;
using Dashboard.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Dashboard.ViewModels
{
    public class CreateNewInspectionViewModel
    {
        public ICommand SaveInspectionCommand { get; }
        public CreateNewInspectionViewModel()
        {
            SaveInspectionCommand = new SaveInspectionCommand(this);
        }
        public void SaveInspection()
        {
            _inspection.Date = Inspection.Date;
            _inspection.Milestone = Inspection.Milestone;
            _inspection.MilestoneReached = Inspection.MilestoneReached;
            _inspection.Inspector = Inspection.Inspector;

            _inspectionRepo.InspecAdd(_inspection);
        }

    }
}
