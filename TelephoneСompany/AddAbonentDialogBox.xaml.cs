using System.Windows;
using TelephoneСompany.Models;

namespace TelephoneСompany
{
    /// <summary>
    /// Логика взаимодействия для AddAbonentDialogBox.xaml
    /// </summary>
    public partial class AddAbonentDialogBox : Window
    {
        public AbonentModel Abonent;
        public AddAbonentDialogBox(AbonentModel abonent)
        {
            InitializeComponent();
            Abonent = abonent;
            DataContext = Abonent;
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
