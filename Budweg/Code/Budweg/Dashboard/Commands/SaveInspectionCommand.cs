using Dashboard.Models;
using Dashboard.ViewModels;
using Dashboard.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
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

        public void Execute(object? parameter) //Object fordi det kan have alle datatyper. Det er den parameter som bliver sendt fra UI'et
        {
            if (parameter is CreateNewInspectionViewModel vm)
            {
                Inspection inspection = vm.Inspection;

                InspectionRepo repo = new InspectionRepo();
                repo.InspecAdd(inspection);

                MessageBox.Show("Saved!");
            }
        }
    }
}
