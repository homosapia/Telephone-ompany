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
            var abonents = _dbAccess.Load<Abonent>("SELECT * FROM Abonents").Select(x => new AbonentTableModel(x));
            Abonents = new ObservableCollection<AbonentTableModel>(abonents);
        }

        public AbonentTableModel SelectedAbonent { get; set; }
        public ObservableCollection<AbonentTableModel> Abonents { get; set; }

        private RelayCommand openTableStreet;
        public RelayCommand OpenTableStreet
        {   
            get 
            {
                return openTableStreet ?? (openTableStreet = new RelayCommand(x => 
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
