using ClientZP.Models;
using ClientZP.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SQLite;
using System.Runtime.CompilerServices;

namespace ClientZP.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private const string DBPath = ":memory:";
        public ObservableCollection<Client> ClientList { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private SQLiteConnection Connect;
        private SQLiteCommand Command;

        #region Properies
        private string _searchtext;
        private bool _deleteEnabled = false;
        private bool _savemenuitemEnabled = false;


        /// <summary>
        /// Активность пункта меню Сохранения файла
        /// </summary>
        public bool SaveFileMenuItemEnabled
        {
            get { return _savemenuitemEnabled; }
            set
            {
                _savemenuitemEnabled = value;
                OnPropertyChanged("SaveFileMenuItemEnabled");
            }
        }

        /// <summary>
        /// Активность пункта меню удаления клиента
        /// </summary>
        public bool DeleteClientMenuItemEnabled
        {
            get { return _deleteEnabled; }
            set
            {
                _deleteEnabled = value;
                OnPropertyChanged("DeleteEnabled");
            }
        }

        /// <summary>
        /// Текст поисковой строки
        /// </summary>
        public string SearchText
        {
            get { return _searchtext; }
            set
            {
                _searchtext = value;
                OnPropertyChanged("SearchText");
                Command = new SQLiteCommand($"SELECT * FROM Client WHERE MATCH '{value}'", Connect);
                ClientList = Command.ExecuteScalar() as ObservableCollection<Client>;
            }
        }
        #endregion

        #region Commands

        /// <summary>
        /// Комманда для пункта главного меню "О программе"
        /// </summary>
        public RelayCommand AboutMenuItemCommand { get; protected set; }
        /// <summary>
        /// Комманда для пункта главного меню "Сотрудник - Добавить"
        /// </summary>
        public RelayCommand AddClientMenuItemCommand { get; protected set; }
        /// <summary>
        /// Комманда для пункта главного меню "Файл - Новый"
        /// </summary>
        public RelayCommand CreateNewFileMenuItem { get; protected set; }
        
        #endregion

        public MainViewModel()
        {
            AboutMenuItemCommand = new RelayCommand(OpenAboutProgramm);
            AddClientMenuItemCommand = new RelayCommand(OpenAddClientPage);
            CreateNewFileMenuItem = new RelayCommand(CreateNewFile);
            Connect = new SQLiteConnection($"Data Source={DBPath};");
            Connect.Open();
        }

        private void OpenAddClientPage(object sender)
        {
            AddClientView add = new AddClientView();
            add.ShowDialog();
        }

        private void CreateNewFile(object sender)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source = :memory:"))
            {
                connection.Open();
                using (SQLiteCommand Command = new SQLiteCommand("CREATE TABLE \"Client\" (\"id\"INTEGER,\"Name\"TEXT NOT NULL,\"Surname\"TEXT NOT NULL,\"Pathnetic\"TEXT NOT NULL,\"HourPay\"REAL,Hours INTEGER, PRIMARY KEY(\"id\" AUTOINCREMENT));", connection))
                {
                    Command.ExecuteNonQuery();
                }
                connection.Close();
            }
            Logger.Log("Buffer-BD created");
            SaveFileMenuItemEnabled = true;
        }

        private void OpenAboutProgramm(object sender)
        {
            AboutProgramView about = new AboutProgramView();
            about.ShowDialog();
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}