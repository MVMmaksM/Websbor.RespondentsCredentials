using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Websbor.Data;
using Websbor.RespondentsCredentials.ViewModel;

namespace Websbor.RespondentsCredentials
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
        }

        private void CreateDb_Click(object sender, RoutedEventArgs e)
        {
            var db = new DbContextOptionsBuilder<WebsborContext>();
            db.UseSqlServer();

            var s = new WebsborContext(db.Options);
            s.Database.EnsureCreated();
        }

        private void MenuItemLoadCredential_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemLoadCatalog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemSaveAllRowCredential_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemSaveCurrentRowsCredential_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemSaveAllRowCatalog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemSaveCurrentRowsCatalog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemShemaLoadCredential_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemShemaLoadCatalog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemCreateDb_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemExecuteSqlQuery_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemDeleteCredential_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemDeleteCatatlog(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemOpenLoadProtocol(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemDirectoryProtocol(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemCurrentLogFile(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemDirectoryLogs(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemDeleteLogs(object sender, RoutedEventArgs e)
        {

        }
    }
}
