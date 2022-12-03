using ClientZP.ViewModels;
using System.Data.SQLite;
using System.Windows;

namespace ClientZP
{
    public partial class MainWindow : Window
    {
        const string BDPath = "bd.db";

        public MainWindow()
        {
            InitializeComponent();
            OnStart();
            DataContext = new MainViewModel();
        }

        public void OnStart()
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source = :memory:"))
            {
                connection.Open();
                SQLiteCommand Command = new SQLiteCommand("CREATE TABLE \"Client\" (\"id\"INTEGER,\"Name\"TEXT NOT NULL,\"Surname\"TEXT NOT NULL,\"Pathnetic\"TEXT NOT NULL,\"HourPay\"REAL,Hours INTEGER, PRIMARY KEY(\"id\" AUTOINCREMENT));", connection);
                Command.ExecuteNonQuery();
                Command.Dispose();
                connection.Close();
            }

        }
    }
}