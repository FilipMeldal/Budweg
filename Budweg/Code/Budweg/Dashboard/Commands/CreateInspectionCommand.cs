using Dashboard.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Dashboard.Commands
{
    public class CreateInspectionCommand : ICommand
    {

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            CreateNewInspection createNewInspection = new CreateNewInspection();
            createNewInspection.Show();
        }
    }
}
