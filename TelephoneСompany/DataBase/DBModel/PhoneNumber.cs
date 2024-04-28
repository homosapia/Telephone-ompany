using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneСompany.DataBase.DBModel
{
    public enum TypeNumder
    {
        home = 0,
        work = 1,
        mobile = 2,
    }

    public class PhoneNumber
    {
        public int id { get; set; }

        public TypeNumder TypeNumber { get; set; }

        public string Number { get; set; }
    }
}
