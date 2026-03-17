using Dashboard.Commands;
using Dashboard.Models;
using Dashboard.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Dashboard.ViewModels
{
    public class CreateNewInspectionViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private readonly NavigationStore _navigationStore;
        public ICommand SaveInspectionCommand { get; }

        public CreateNewInspectionViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            SaveInspectionCommand = new SaveInspectionCommand();

        }
    }
}
