using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientZP.Models
{
    public class Client
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private string _surname;
        private string _pathnetic;
        private double _hours;
        private double _hourpay;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string SurName
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("SurName");
            }
        }
        public string Pathnetic
        {
            get { return _pathnetic; }
            set
            {
                _pathnetic = value;
                OnPropertyChanged("Pathnetic");
            }
        }
        public double HourPay
        {
            get { return _hourpay; }
            set
            {
                _hourpay = value;
                OnPropertyChanged("HourPay");
            }
        }
        public double Hours
        {
            get { return _hours; }
            set
            {
                _hours = value;
                OnPropertyChanged("Hours");
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}