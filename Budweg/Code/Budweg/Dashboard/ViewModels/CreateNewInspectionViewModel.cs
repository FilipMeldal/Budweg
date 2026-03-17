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

        private Inspection _inspection;

        public Inspection Inspection
        {
            get { return _inspection; }
            set
            {
                _inspection = value;
                OnPropertyChanged(nameof(Inspection));
            }
        }

        public CreateNewInspectionViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            Inspection = new Inspection();
            SaveInspectionCommand = new SaveInspectionCommand();
        }
    }
}
