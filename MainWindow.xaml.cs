using ClientZP.ViewModels;
using System.Data.SQLite;
using System.Windows;

namespace ClientZP
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}