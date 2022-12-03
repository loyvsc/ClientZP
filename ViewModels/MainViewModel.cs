using ClientZP.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace ClientZP.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private const string DBPath = ":memory:";
        public ObservableCollection<Client> ClientList { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private SQLiteConnection Connect;
        private SQLiteCommand Command;
        private string _searchtext;
        public static RoutedCommand AboutProgramCommand { get; protected set; }

        /// <summary>
        /// Текст поисковой строки
        /// </summary>
        public string SearchText
        {
            get
            {
                return _searchtext;
            }
            set
            {
                _searchtext = value;
                Command = new SQLiteCommand($"SELECT * FROM Client WHERE MATCH '{value}'", Connect);
                ClientList = Command.ExecuteScalar() as ObservableCollection<Client>;
                OnPropertyChanged("SearchText");
            }
        }

        public MainViewModel()
        {
            Connect = new SQLiteConnection($"Data Source={DBPath};");
            Connect.Open();                             
            AboutProgramCommand = new RoutedCommand("AboutProgramCommand", typeof(MainWindow));
            
        }

        private void AboutProgramCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("AboutProgram");
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}