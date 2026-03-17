using Dashboard.ViewModels;
using Dashboard.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //MainViewModel mvm;
        public MainWindow()
        {
            //mvm = new MainViewModel();
            InitializeComponent();
           // DataContext = mvm;
        }

        private void CreateInspectionDialog_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}