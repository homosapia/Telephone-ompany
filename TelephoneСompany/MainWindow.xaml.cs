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

            var appDBContext = new AppDBContext();
            appDBContext.Database.EnsureCreated();

            DataContext = new TableAbonentsViewModel(connectionStrings);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}