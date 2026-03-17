using Dashboard.Commands;
using Dashboard.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Dashboard.Services;

namespace Dashboard.ViewModels
{
    public class DashBoardViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        public ICommand CreateInspectionCommand { get; }
        public ICommand NavigateToInspectionCommand { get; }

        public DashBoardViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            CreateInspectionCommand = new CreateInspectionCommand();
            NavigateToInspectionCommand = new NavigateCommand(new NavigationService(navigationStore, () => new CreateNewInspectionViewModel(navigationStore)));
        }
    }
}
