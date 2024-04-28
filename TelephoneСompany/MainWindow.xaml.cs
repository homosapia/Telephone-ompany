using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Windows;
using TelephoneСompany.DataBase;
using TelephoneСompany.ViewModels;

namespace TelephoneСompany
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string connectionStrings = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuilder.UseSqlite(connectionStrings);

            DataContext = new TableAbonentsViewModel(connectionStrings);
        }

        private void ExportCsvButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void StreetsButton_Click(object sender, RoutedEventArgs e)
        {
            var streetsWindow = new ModalWindowStreets();
            streetsWindow.Owner = this;
            streetsWindow.Show();
        }
    }
}