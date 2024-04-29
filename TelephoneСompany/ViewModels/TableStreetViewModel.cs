using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TelephoneСompany.Commands;
using TelephoneСompany.DataBase;
using TelephoneСompany.DataBase.DBModel;
using TelephoneСompany.Models;

namespace TelephoneСompany.ViewModels
{
    public class TableStreetViewModel : INotifyPropertyChanged
    {
        private DatabaseAccess _dbAccess;

        public TableStreetViewModel(string connectionString)
        {
            _dbAccess = new DatabaseAccess(connectionString);
            var streets = _dbAccess.Load<Street>("SELECT * FROM Streets").Select(x => new StreetModel(x));
            Streets = new ObservableCollection<StreetModel>(streets);
        }

        public StreetModel SelectedStreet { get; set; }
        public ObservableCollection<StreetModel> Streets { get; set; }

        private RelayCommand openDialogStreet;
        public RelayCommand OpenDialogStreet
        {
            get
            {
                return openDialogStreet ?? (openDialogStreet = new RelayCommand(x =>
                {
                    var window = new AddStreetDialogBox(new StreetModel());
                    if (window.ShowDialog() == true)
                    {
                        var streetModel = window.Street;
                        Streets.Insert(0, streetModel);
                        Street street = new Street()
                        {
                            Name = streetModel.Name,
                            HouseNumber = streetModel.HouseNumber,
                        };
                        _dbAccess.Save<Street>("INSERT INTO Streets (Name, HouseNumber) VALUES (@Name, @HouseNumber)", street);
                    }
                }));
            }
        }

        private RelayCommand addAbonent;
        public RelayCommand AddAbonent
        {
            get
            {
                return addAbonent ?? (addAbonent = new RelayCommand(x =>
                {
                    var window = new AddStreetDialogBox(new StreetModel());
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
