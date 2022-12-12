using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientZP.ViewModels
{
    public class AddClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public AddClientViewModel()
        {
            ADDButtonCommand = new RelayCommand(ADDClient);
        }

        #region Properties
        private string _surname = null;
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }

        private string _name = null;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _pathnetic = null;
        public string Pathnetic
        {
            get { return _pathnetic; }
            set
            {
                _pathnetic = value;
                OnPropertyChanged("Pathnetic");
            }
        }

        private string _dolghnost = null;
        public string Dolghnost
        {
            get { return _dolghnost; }
            set
            {
                _pathnetic = value;
                OnPropertyChanged("Pathnetic");
            }
        }

        private string _countofhours = null;
        public string CountOfHours
        {
            get { return _countofhours; }
            set
            {
                _pathnetic = value;
                OnPropertyChanged("CountOfHours");
            }
        }

        private string _zpinhour = null;
        public string ZPinHour
        {
            get { return _zpinhour; }
            set
            {
                _pathnetic = value;
                OnPropertyChanged("ZPinHour");
            }
        }
        #endregion

        #region Commands
        public RelayCommand ADDButtonCommand { get; protected set; }
        #endregion

        private void ADDClient(object sender)
        {

            Logger.Log("BD | ADD Client");
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
