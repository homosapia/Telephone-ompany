using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TelephoneСompany.DataBase;
using TelephoneСompany.ViewModels;

namespace TelephoneСompany
{
    /// <summary>
    /// Логика взаимодействия для ModalWindowStreets.xaml
    /// </summary>
    public partial class ModalWindowStreets : Window
    {
        public ModalWindowStreets()
        {
            InitializeComponent();
            string connectionStrings = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            var appDBContext = new AppDBContext();
            appDBContext.Database.EnsureCreated();

            DataContext = new TableStreetViewModel(connectionStrings);
        }
    }
}
