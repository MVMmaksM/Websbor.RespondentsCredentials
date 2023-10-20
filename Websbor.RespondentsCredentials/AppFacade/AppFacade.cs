using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websbor.Data;
using Websbor.Data.Model;
using Websbor.Data.Repository;
using Websbor.RespondentsCredentials.Services;
using Websbor.RespondentsCredentials.View;
using Websbor.RespondentsCredentials.ViewModel;

namespace Websbor.RespondentsCredentials.AppFacade
{
    internal class AppFacade : IAppFacade
    {
        private readonly ICatalogWebsborAsgsRepository _catalogRepository;
        private readonly ICredentialsRepository _credentialsRepository;
        private readonly IMessageService _messageService;
        private ApplicationViewModel _applicationViewModel;
        public AppFacade(IMessageService messageService, ApplicationViewModel applicationViewModel,
            ICredentialsRepository credentialsRepository, ICatalogWebsborAsgsRepository catalogRepository)
        {
            _messageService = messageService;
            _applicationViewModel = applicationViewModel;
            _credentialsRepository = credentialsRepository;
            _catalogRepository = catalogRepository;
        }

        #region работа с каталогом      
        public void AddCatalog(MainWindow mainWindow)
        {
            var addCatalogWindow = new AddAndEditCatalogWindow(_messageService, _catalogRepository);
            addCatalogWindow.Owner = mainWindow;
            addCatalogWindow.Show();
        }
        public async void DeleteCatalogRow()
        {
            try
            {
                await _catalogRepository.DeleteCatalogAsync(_applicationViewModel.SelectedCatalog);
                _applicationViewModel.Catalog.Remove(_applicationViewModel.SelectedCatalog);

                _messageService.Info("Запись удалена из базы данных!");
            }
            catch (Exception ex)
            {
                _messageService.Error(ex.Message);
            }
        }
        public void EditCatalog(MainWindow mainWindow)
        {
            if (_applicationViewModel.SelectedCatalog is not null)
            {
                var addCatalogWindow = new AddAndEditCatalogWindow(_messageService, _catalogRepository, _applicationViewModel.SelectedCatalog);
                addCatalogWindow.Owner = mainWindow;
                addCatalogWindow.Show();
            }
        }
        public async void DeleteCatalog()
        {
            var countAllRows = await _catalogRepository.GetCountCatalogAsync();

            if (_messageService.Question($"Внимание! Из таблицы будут удалены все данные. \nКоличество записей в таблице: {countAllRows}.\nОчистить таблицу?"))
            {
                try
                {
                    var countDeleted = await _catalogRepository.DeleteAllCatalogAsync();
                    _messageService.Info($"Удалено записей из таблицы: {countDeleted}");
                }
                catch (Exception ex)
                {
                    _messageService.Error(ex.Message);
                }
            }
        }
        public async void GetAllCatalog()
        {
            try
            {
                var catalog = await _catalogRepository.GetAllCatalogAsync();
                _applicationViewModel.Catalog = new BindingList<CatalogWebsborAsgs>(catalog);
            }
            catch (Exception ex)
            {
                _messageService.Error(ex.Message);
            }
        }
        public async void SearchCatalog()
        {
            try
            {
                BindingList<CatalogWebsborAsgs> searchResult = null;

                if (!string.IsNullOrWhiteSpace(_applicationViewModel.SearchCatalog.SearchByOkpo) && !string.IsNullOrWhiteSpace(_applicationViewModel.SearchCatalog.SearchByName))
                {
                    var result = await _catalogRepository.GetCatalogByNameAndOkpoAsync(_applicationViewModel.SearchCatalog.SearchByName, _applicationViewModel.SearchCatalog.SearchByOkpo);
                    searchResult = new BindingList<CatalogWebsborAsgs>(result);
                }
                else if (!string.IsNullOrWhiteSpace(_applicationViewModel.SearchCatalog.SearchByOkpo) && string.IsNullOrWhiteSpace(_applicationViewModel.SearchCatalog.SearchByName))
                {
                    var result = await _catalogRepository.GetCatalogByLikeOkpoAsync(_applicationViewModel.SearchCatalog.SearchByOkpo);
                    searchResult = new BindingList<CatalogWebsborAsgs>(result);
                }
                else if (string.IsNullOrWhiteSpace(_applicationViewModel.SearchCatalog.SearchByOkpo) && !string.IsNullOrWhiteSpace(_applicationViewModel.SearchCatalog.SearchByName))
                {
                    var result = await _catalogRepository.GetCatalogByNameAsync(_applicationViewModel.SearchCatalog.SearchByName);
                    searchResult = new BindingList<CatalogWebsborAsgs>(result);
                }

                if (searchResult is not null)
                {
                    _applicationViewModel.Catalog = searchResult;
                }
            }
            catch (Exception ex)
            {
                _messageService.Error(ex.Message);
            }
        }
        #endregion

        #region работа с файлами
        public void SaveAllCatalog()
        {
            throw new NotImplementedException();
        }
        public void SaveCurrentRowsCatalog()
        {
            throw new NotImplementedException();
        }
        public void LoadCatalog()
        {
            throw new NotImplementedException();
        }

        public void LoadCredential()
        {
            throw new NotImplementedException();
        }
        public void SaveAllCredential()
        {
            throw new NotImplementedException();
        }
        public void SaveCurrentRowsCredential()
        {
            throw new NotImplementedException();
        }
        public void ShemaLoadCatalog()
        {
            throw new NotImplementedException();
        }

        public void ShemaLoadCredential()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region работа с учетными данными
        public void AddCredential(MainWindow mainWindow)
        {
            var addCredentialWindow = new AddAndEditCredentialWindow(_catalogRepository, _messageService, _credentialsRepository);
            addCredentialWindow.Owner = mainWindow;
            addCredentialWindow.Show();
        }
        public async void DeleteCredential()
        {
            var countAllRows = await _credentialsRepository.GetCountCredentialsAsync();

            if (_messageService.Question($"Внимание! Из таблицы будут удалены все данные. \nКоличество записей в таблице: {countAllRows}.\nОчистить таблицу?"))
            {
                try
                {
                    var countDeleted = await _credentialsRepository.DeleteAllCredential();
                    _messageService.Info($"Удалено записей из таблицы: {countDeleted}");
                }
                catch (Exception ex)
                {
                    _messageService.Error(ex.Message);
                }
            }
        }
        public async void DeleteCredentialRow()
        {
            try
            {
                await _credentialsRepository.DeleteCredentialAsync(_applicationViewModel.SelectedCredential);
                _applicationViewModel.Credentials.Remove(_applicationViewModel.SelectedCredential);

                _messageService.Info("Запись удалена из базы данных!");
            }
            catch (Exception ex)
            {
                _messageService.Error(ex.Message);
            }
        }
        public void EditCredential(MainWindow mainWindow)
        {
            if (_applicationViewModel.SelectedCredential is not null)
            {
                var editCredentialWindow = new AddAndEditCredentialWindow(_catalogRepository, _messageService, _credentialsRepository,
                _applicationViewModel.SelectedCredential);
                editCredentialWindow.Owner = mainWindow;
                editCredentialWindow.Show();
            }
        }
        public async void GetAllCredential()
        {
            try
            {
                var credentials = await _credentialsRepository.GetAllCredentialsAsync();
                _applicationViewModel.Credentials = new BindingList<Credentials>(credentials);
            }
            catch (Exception ex)
            {
                _messageService.Error(ex.Message);
            }
        }
        public async void SearchCredential()
        {
            try
            {
                BindingList<Credentials> searchResult = null;

                if (!string.IsNullOrWhiteSpace(_applicationViewModel.SearchCredential.SearchByOkpo) && !string.IsNullOrWhiteSpace(_applicationViewModel.SearchCredential.SearchByName))
                {
                    var result = await _credentialsRepository.GetCredentialByNameAndOkpoAsync(_applicationViewModel.SearchCredential.SearchByName, _applicationViewModel.SearchCredential.SearchByOkpo);
                    searchResult = new BindingList<Credentials>(result);
                }
                else if (!string.IsNullOrWhiteSpace(_applicationViewModel.SearchCredential.SearchByOkpo) && string.IsNullOrWhiteSpace(_applicationViewModel.SearchCredential.SearchByName))
                {
                    var result = await _credentialsRepository.GetCredentialByOkpoAsync(_applicationViewModel.SearchCredential.SearchByOkpo);
                    searchResult = new BindingList<Credentials>(result);
                }
                else if (string.IsNullOrWhiteSpace(_applicationViewModel.SearchCredential.SearchByOkpo) && !string.IsNullOrWhiteSpace(_applicationViewModel.SearchCredential.SearchByName))
                {
                    var result = await _credentialsRepository.GetCredentialByNameAsync(_applicationViewModel.SearchCredential.SearchByName);
                    searchResult = new BindingList<Credentials>(result);
                }

                if (searchResult is not null)
                {
                    _applicationViewModel.Credentials = searchResult;
                }
            }
            catch (Exception ex)
            {
                _messageService.Error(ex.Message);
            }
        }
        #endregion

        #region работа с log
        public void DeleteLogs()
        {
            throw new NotImplementedException();
        }
        public void OpenCurrentLogFile()
        {
            throw new NotImplementedException();
        }

        public void OpenDirectoryLogs()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region работа с протоколом
        public void OpenDirectoryProtocol()
        {
            throw new NotImplementedException();
        }

        public void OpenProtocol()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region запросы к БД
        public async void CreateDb()
        {
            var optionBuilder = new DbContextOptionsBuilder<WebsborContext>();
            optionBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=AwesomeNetwork;Trusted_Connection=True;Encrypt=false;Integrated Security=True;");

            var dbContext = new WebsborContext(optionBuilder.Options);
            var isCreateDb = await dbContext.Database.EnsureCreatedAsync();

            if (isCreateDb)
            {
                _messageService.Info("База данных создана!");
            }
            else
            {
                _messageService.Error("База данных не создана!");
            }
        }
        public void ExecuteSqlQuery()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
