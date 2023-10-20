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
using Websbor.RespondentsCredentials.AppFacade;
using Websbor.RespondentsCredentials.Services.Logger;
using Websbor.RespondentsCredentials.ViewModel;

namespace Websbor.RespondentsCredentials
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAppFacade _appFacade;
        private readonly ILoggerService _loggerService;
        public MainWindow(IAppFacade appFacade, ApplicationViewModel applicationViewModel, ILoggerService loggerService)
        {
            _loggerService = loggerService;
            _loggerService.Info("Запуск приложения");

            InitializeComponent();
            _appFacade = appFacade;
            DataContext = applicationViewModel;
        }

        #region меню Файл
        private void MenuItemLoadCredential_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.LoadCredential();
        }

        private void MenuItemLoadCatalog_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.LoadCatalog();
        }

        private void MenuItemSaveAllRowCredential_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.SaveAllCredential();
        }

        private void MenuItemSaveCurrentRowsCredential_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.SaveCurrentRowsCredential();
        }

        private void MenuItemSaveAllRowCatalog_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.SaveAllCatalog();
        }

        private void MenuItemSaveCurrentRowsCatalog_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.SaveCurrentRowsCatalog();
        }

        private void MenuItemShemaLoadCredential_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.ShemaLoadCredential();
        }

        private void MenuItemShemaLoadCatalog_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.ShemaLoadCatalog();
        }
        #endregion

        #region меню БД
        private void MenuItemCreateDb_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.CreateDb();
        }

        private void MenuItemExecuteSqlQuery_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.ExecuteSqlQuery();
        }

        private void MenuItemDeleteCredential_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.DeleteCredential();
        }

        private void MenuItemDeleteCatalog_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.DeleteCatalog();
        }
        #endregion

        #region меню Протокол
        private void MenuItemOpenProtocol(object sender, RoutedEventArgs e)
        {
            _appFacade.OpenProtocol();
        }

        private void MenuItemOpenDirectoryProtocol(object sender, RoutedEventArgs e)
        {
            _appFacade.OpenDirectoryProtocol();
        }
        #endregion

        #region меню log
        private void MenuItemOpenCurrentLogFile(object sender, RoutedEventArgs e)
        {
            _appFacade.OpenCurrentLogFile();
        }

        private void MenuItemOpenDirectoryLogs(object sender, RoutedEventArgs e)
        {
            _appFacade.OpenDirectoryLogs();
        }

        private void MenuItemDeleteLogs(object sender, RoutedEventArgs e)
        {
            _appFacade.DeleteLogs();
        }
        #endregion

        #region кнопки работы с учетными данными
        private void ButtonAddCredential_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.AddCredential(this);
        }

        private void BtnDeleteCredential_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.DeleteCredentialRow();
        }

        private void BtnGetAllCredential_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.GetAllCredential();
        }

        private void BtnEditCredential_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.EditCredential(this);
        }
        private void BtnSearchCredential_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.SearchCredential();
        }
        #endregion

        #region кнопки работы с каталогом web-сбора
        private void BtnAddCatalog_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.AddCatalog(this);
        }

        private void BtnEditCatalog_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.EditCatalog(this);
        }

        private void BtnGetAllCatalog_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.GetAllCatalog();
        }

        private void BtnSearchCatalog_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.SearchCatalog();
        }

        private void BtnDeleteCatalog_Click(object sender, RoutedEventArgs e)
        {
            _appFacade.DeleteCatalogRow();
        }
        #endregion

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            _loggerService.Info("Закрытие приложения");
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void dgCredentials_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }

        private void TxtBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dgCatalog_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }

        private void TxtBxSearchCatalog_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void BtnSaveSettings_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
