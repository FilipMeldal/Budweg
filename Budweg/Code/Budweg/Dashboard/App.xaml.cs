using Dashboard.Stores;
using Dashboard.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Dashboard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            NavigationStore navigationStore = new NavigationStore();

            navigationStore.CurrentViewModel = new DashBoardViewModel(navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();
        }
    }

}
