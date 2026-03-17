using Dashboard.Commands;
using Dashboard.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Dashboard.ViewModels
{
    public class DashBoardViewModel : BaseViewModel
    {
        public ICommand CreateInspectionCommand { get; }

        public DashBoardViewModel(NavigationStore navigationStore)
        {
            CreateInspectionCommand = new CreateInspectionCommand();
        }
    }
}
