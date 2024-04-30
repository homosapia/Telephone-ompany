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
            GetAnswerSearchQuery(string.Empty);
        }

        public AbonentTableModel SelectedAbonent { get; set; }
        public ObservableCollection<AbonentTableModel> Abonents { get; set; }

        private string _searchQuery;
        public string SearchQuery 
        { 
            get => _searchQuery;
            
            set
            { 
                _searchQuery = value;
                GetAnswerSearchQuery(_searchQuery);
                OnPropertyChanged("SearchQuery");
            } 
        }

        private RelayCommand _search;
        public RelayCommand Search
        {
            get
            {
                return _search ?? (_search = new RelayCommand(x =>
                {
                    GetAnswerSearchQuery(_searchQuery);
                }));
            }
        }

        private void GetAnswerSearchQuery(string searchQuery)
        {
            var abonents = _dbAccess.Load<Abonent>("SELECT * FROM Abonents").Select(x => new AbonentTableModel(x));
            abonents = abonents.Where(x => x.MatchesSearchQuery(SearchQuery));
            AbonentTableModel I = new AbonentTableModel(new Abonent()
            {
                FirstName = "Бадажков",
                MiddleName = "Павел",
                LastName = "Максчимович",
                Address = new Address()
                {
                    StreetName = "Верейска",
                    HouseNumber = "12"
                },
                Numbers = new List<PhoneNumber>()
                {
                    new PhoneNumber(){ Number = "12345234", TypeNumber = TypeNumder.home },
                    new PhoneNumber(){ Number = "89964130187", TypeNumber = TypeNumder.mobile },
                    new PhoneNumber(){ Number = "4345234", TypeNumber = TypeNumder.mobile },
                    new PhoneNumber(){ Number = "1452345234", TypeNumber = TypeNumder.home },
                    new PhoneNumber(){ Number = "78345234", TypeNumber = TypeNumder.work }
                }
            });
            Abonents = new ObservableCollection<AbonentTableModel>(abonents);
            if (I.MatchesSearchQuery(searchQuery))
                Abonents.Add(I);

            OnPropertyChanged("Abonents");
        }

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

        private RelayCommand createCSV;
        public RelayCommand CreateCSV
        {
            get
            {
                return createCSV ?? (createCSV = new RelayCommand(x =>
                {
                    CsvExporter csvExporter = new CsvExporter();
                    csvExporter.ExportToCsv(Abonents);
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
