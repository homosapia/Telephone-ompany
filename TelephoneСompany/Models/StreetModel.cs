using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TelephoneСompany.DataBase.DBModel;

namespace TelephoneСompany.Models
{
    public class StreetModel : INotifyPropertyChanged
    {
        private string _name { get; set; }
        private string _houseNumber { get; set; }
        private int _countAbonents { get; set; }

        public StreetModel() { }
        public StreetModel(Street street)
        {
            _name = street.Name;
            _houseNumber = street.HouseNumber;
            _countAbonents = street.Abonents?.Count ?? 0;
        }

        public string Name 
        { 
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string HouseNumber
        {
            get => _houseNumber;
            set
            {
                _houseNumber = value;
                OnPropertyChanged("HouseNumber");
            }
        }

        public int CountAbonents
        {
            get => _countAbonents;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
