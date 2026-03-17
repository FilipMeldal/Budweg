using Dashboard.Stores;
using Dashboard.ViewModels;
using Dashboard.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Dashboard.Commands
{
    public class CreateInspectionCommand : ICommand
    {
        private readonly NavigationStore _navigationStore;
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            CreateNewInspectionViewModel viewModel = new CreateNewInspectionViewModel(_navigationStore);
            
            CreateNewInspectionView createNewInspection = new CreateNewInspectionView
            {
                DataContext = viewModel
            };
            createNewInspection.Show();
        }
    }
}
