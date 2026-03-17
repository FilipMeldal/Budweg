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
        private MainViewModel mvm;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter) //Object fordi det kan have alle datatyper. Det er den parameter som bliver sendt fra UI'et
        {
            MessageBox.Show("Test");
        }
    }
}
