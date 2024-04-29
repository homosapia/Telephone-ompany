using System;
using System.Collections.Generic;
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
using TelephoneСompany.Models;

namespace TelephoneСompany
{
    /// <summary>
    /// Логика взаимодействия для AddAbonentDialogBox.xaml
    /// </summary>
    public partial class AddAbonentDialogBox : Window
    {
        public AbonentTableModel Abonent;
        public AddAbonentDialogBox(AbonentTableModel abonent)
        {
            InitializeComponent();
            Abonent = abonent;
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
