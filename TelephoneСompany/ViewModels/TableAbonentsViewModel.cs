using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;
using TelephoneСompany.Commands;
using TelephoneСompany.DataBase;
using TelephoneСompany.DataBase.DBModel;
using TelephoneСompany.Models;

namespace TelephoneСompany.ViewModels
{
    public class TableAbonentsViewModel : INotifyPropertyChanged
    {
        private DatabaseAccess _dbAccess;

        public TableAbonentsViewModel(string connectionString) 
        {
            _dbAccess = new DatabaseAccess(connectionString);
            Abonents = new ObservableCollection<AbonentModel>
            {
                new AbonentModel(new Abonent()
                {
                    Address = new Address(){ StreetName = "улица ывф", HouseNumber = "123asd"},
                    FirstName = "Бадажков",
                    MiddleName = "Павел",
                    LastName = "Максимович",
                    Numbers = new List<PhoneNumber>()
                    {
                        new PhoneNumber() {TypeNumber = TypeNumder.home, Number = "+1235363"},
                        new PhoneNumber() {TypeNumber = TypeNumder.work, Number = "+12323454563"},
                        new PhoneNumber() {TypeNumber = TypeNumder.mobile, Number = "+123345655363"},
                        new PhoneNumber() {TypeNumber = TypeNumder.mobile, Number = "+4233455363"}
                    }
                }),
            };
        }

        public AbonentModel SelectedAbonent { get; set; }
        public ObservableCollection<AbonentModel> Abonents { get; set; }

        private RelayCommand addCommand;
        public RelayCommand AddCommand 
        {   
            get 
            {
                return addCommand ?? (addCommand = new RelayCommand(x => 
                {
                    var windowStreet = new ModalWindowStreets();
                    windowStreet.ShowDialog();
                }));
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
