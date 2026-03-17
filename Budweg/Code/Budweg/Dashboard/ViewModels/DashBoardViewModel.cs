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

        public DashBoardViewModel(NavigationStore navigationStore)
        {
            CreateInspectionCommand = new CreateInspectionCommand();
        }
    }
}
