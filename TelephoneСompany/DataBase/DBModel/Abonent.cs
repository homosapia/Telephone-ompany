using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneСompany.DataBase.DBModel
{
    public class Abonent
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }

        public List<PhoneNumber>? Numbers { get; set; }
    }
}
