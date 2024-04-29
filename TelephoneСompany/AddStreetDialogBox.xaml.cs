using System.Configuration;
using System.Windows;
using TelephoneСompany.DataBase;
using TelephoneСompany.DataBase.DBModel;
using TelephoneСompany.Models;
using TelephoneСompany.ViewModels;

namespace TelephoneСompany
{
    /// <summary>
    /// Логика взаимодействия для AddStreetDialogBox.xaml
    /// </summary>
    public partial class AddStreetDialogBox : Window
    {
        public StreetModel Street;
        public AddStreetDialogBox(StreetModel street)
        {
            InitializeComponent();
            Street = street;
            DataContext = Street;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
