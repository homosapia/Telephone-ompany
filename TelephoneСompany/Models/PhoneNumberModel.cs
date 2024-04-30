using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneСompany.Models
{
    public enum TypeNumderModel
    {
        home = 0,
        work = 1,
        mobile = 2,
    }

    public class PhoneNumberModel : INotifyPropertyChanged
    {
        private TypeNumderModel _typeNumderModel;
        private string _number;

        public TypeNumderModel TypeNumder
        {
            get { return _typeNumderModel; }
            set
            {
                _typeNumderModel = value;
                OnPropertyChanged("TypeNumder");
            }
        }

        public string Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
