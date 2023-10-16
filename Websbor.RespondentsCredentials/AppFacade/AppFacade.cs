using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websbor.Data;
using Websbor.Data.Model;
using Websbor.Data.Repository;
using Websbor.RespondentsCredentials.Services;
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
        public void AddCatalog()
        {
            throw new NotImplementedException();
        }

        public void AddCredential()
        {
            var cred = new Credentials { Okpo = "123123", Name = "ОАО", Password = "sd786Gug*/", UserCreate = "Ivan", UserUpdate = "Mixa", Comment = "лорлфыао", DateCreate = DateTime.Now };


            try
            {
                _credentialsRepository.SaveCredentialAsync(cred);
            }
            catch (Exception ex)
            {
                _messageService.Error(ex.Message);
            }
        }

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

        public void DeleteCatalog()
        {
            throw new NotImplementedException();
        }

        public void DeleteCatalogRow()
        {
            throw new NotImplementedException();
        }

        public void DeleteCredential()
        {
            throw new NotImplementedException();
        }

        public void DeleteCredentialRow()
        {
            throw new NotImplementedException();
        }

        public void DeleteLogs()
        {
            throw new NotImplementedException();
        }

        public void EditCatalog()
        {
            throw new NotImplementedException();
        }

        public void EditCredential()
        {
            throw new NotImplementedException();
        }

        public void ExecuteSqlQuery()
        {
            throw new NotImplementedException();
        }

        public void GetAllCatalog()
        {
            throw new NotImplementedException();
        }

        public async void GetAllCredential()
        {
            _applicationViewModel.Credentials = new List<Credentials>(await _credentialsRepository.GetAllCredentialsAsync());
            //_applicationViewModel.Credentials = new List<Credentials>
            //{
            //    new Credentials { Okpo = "123123", Name = "ОАО", Password = "sd786Gug*/", UserCreate = "Ivan", UserUpdate = "Mixa", Comment = "лорлфыао", DateCreate = DateTime.Now } };

        }

        public void LoadCatalog()
        {
            throw new NotImplementedException();
        }

        public void LoadCredential()
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

        public void OpenDirectoryProtocol()
        {
            throw new NotImplementedException();
        }

        public void OpenProtocol()
        {
            throw new NotImplementedException();
        }

        public void SaveAllCatalog()
        {
            throw new NotImplementedException();
        }

        public void SaveAllCredential()
        {
            throw new NotImplementedException();
        }

        public void SaveCurrentRowsCatalog()
        {
            throw new NotImplementedException();
        }

        public void SaveCurrentRowsCredential()
        {
            throw new NotImplementedException();
        }

        public void SearchCatalog()
        {
            throw new NotImplementedException();
        }

        public void SearchCredential()
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
    }
}
