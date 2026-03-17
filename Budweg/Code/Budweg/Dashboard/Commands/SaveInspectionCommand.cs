using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Dashboard.Commands
{
    public class SaveInspectionCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            InspectionRepo repo = new InspectionRepo();
            repo.InspecAdd();
        }
    }
}
