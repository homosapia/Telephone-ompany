using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TelephoneСompany.Commands;

namespace TelephoneСompany.Models
{
    public class AbonentModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _streetName;
        private string _houseNumber;

        public PhoneNumberModel SelectedPhoneNumbers { get; set; }
        public ObservableCollection<PhoneNumberModel> PhoneNumbers { get; set; }

        public AbonentModel()
        {
            PhoneNumbers = new ObservableCollection<PhoneNumberModel>();
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string MiddleName
        {
            get => _middleName;
            set
            {
                _middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string StreetName
        {
            get => _streetName;
            set
            {
                _streetName = value;
                OnPropertyChanged("StreetName");
            }
        }

        public string HouseNumber
        {
            get => _houseNumber;
            set
            {
                _houseNumber = value;
                OnPropertyChanged("StreetName");
            }
        }

        private RelayCommand _addPhoneNumber;
        public RelayCommand AddPhoneNumber
        {
            get
            {
                return _addPhoneNumber ?? (_addPhoneNumber = new RelayCommand(x =>
                {
                    PhoneNumberModel phoneNumber = new PhoneNumberModel();
                    SelectedPhoneNumbers = phoneNumber;
                    PhoneNumbers.Add(phoneNumber);
                }));
            }
        }

        public RelayCommand DeletePhoneNumber
        {
            get
            {
                return new RelayCommand(x =>
                {
                    PhoneNumbers.Remove(SelectedPhoneNumbers);
                    SelectedPhoneNumbers = PhoneNumbers.First();
                });
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
