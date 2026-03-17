using Dashboard.Models;
using Dashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Dashboard.Commands
{
    public class SaveInspectionCommand : ICommand
    {
        readonly MainViewModel _mvm;

        public event EventHandler? CanExecuteChanged;

        public SaveInspectionCommand(MainViewModel mvm)
        {
            _mvm = mvm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter) //Object fordi det kan have alle datatyper. Det er den parameter som bliver sendt fra UI'et
        {
            // Try to use the command parameter (usually bound from the UI).
            var inspectionVM = parameter as InspectionViewModel ?? _mvm.SelectedInspection;
            if (inspectionVM == null) return;

            // Convert the view model to the domain model expected by MainViewModel.SaveInspection.
            var inspection = new Inspection
            {
                Id = inspectionVM.Id,
                Date = inspectionVM.Date,
                Milestone = inspectionVM.Milestone,
                MilestoneReached = inspectionVM.MilestoneReached,
                Inspector = inspectionVM.Inspector
            };

            _mvm.SaveInspection(inspection); //Bruger Command AddInspection fra MainViewModel
        }
    }
}
