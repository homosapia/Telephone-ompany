using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneСompany.DataBase.DBModel
{
    public class Street
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string HouseNumber { get; set; }

        public List<Abonent> Abonents { get; set; }
    }
}
