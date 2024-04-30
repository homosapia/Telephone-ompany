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
    public class AbonentTableModel
    {
        private string _nameAbonent { get; set; }
        private string _street {  get; set; }
        private string _houseNumber {  get; set; }
        private List<string> _homePhone { get; set; }
        private List<string> _workPhone { get; set; }
        private List<string> _mobilePhone { get; set; }

        public AbonentTableModel(Abonent abonent)
        {
            _nameAbonent = $"{abonent.FirstName} {abonent.MiddleName} {abonent.LastName}";
            _street = abonent.Address.StreetName;
            _houseNumber = abonent.Address.HouseNumber;
            _homePhone = abonent.Numbers.Where(x => x.TypeNumber == TypeNumder.home).Select(x => x.Number).ToList();
            _workPhone = abonent.Numbers.Where(x => x.TypeNumber == TypeNumder.work).Select(x => x.Number).ToList();
            _mobilePhone = abonent.Numbers.Where(x => x.TypeNumber == TypeNumder.mobile).Select(x => x.Number).ToList();
        }

        public bool MatchesSearchQuery(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
                return true;

            if(_nameAbonent.Contains(searchQuery))
                return true;

            if (_street.Contains(searchQuery))
                return true;

            if(_houseNumber.Contains(searchQuery))
                return true;

            if(_homePhone.Any(x => x.Contains(searchQuery)))
                return true;

            if (_workPhone.Any(x => x.Contains(searchQuery)))
                return true;

            if (_mobilePhone.Any(x => x.Contains(searchQuery)))
                return true;

            return false;
        }

        public string NameAbonent
        {
            get => _nameAbonent;
        }

        public string Street
        {
            get => _street;
        }

        public string HouseNumber
        {
            get => _houseNumber;
        }

        public string HomePhone
        {
            get => string.Join("\n\r", _homePhone);
        }

        public string WorkPhone
        {
            get => string.Join("\n\r", _workPhone);
        }

        public string MobilePhone
        {
            get => string.Join("\n\r", _mobilePhone);
        }
    }
}
