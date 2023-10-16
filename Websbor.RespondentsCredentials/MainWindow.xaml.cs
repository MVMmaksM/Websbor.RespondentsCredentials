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
    }
}
