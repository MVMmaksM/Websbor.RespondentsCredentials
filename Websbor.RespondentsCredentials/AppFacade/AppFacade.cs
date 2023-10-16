using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websbor.Data;
using Websbor.RespondentsCredentials.Services;

namespace Websbor.RespondentsCredentials.AppFacade
{
    internal class AppFacade : IAppFacade
    {
        private readonly IMessageService _messageService;
        public AppFacade(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public void AddCatalog()
        {
            throw new NotImplementedException();
        }

        public void AddCredential()
        {
            throw new NotImplementedException();
        }

        public async void CreateDb()
        {
            var optionBuilder = new DbContextOptionsBuilder<WebsborContext>();
            optionBuilder.UseSqlServer(/*строка подключения*/);

            var dbContext = new WebsborContext(optionBuilder.Options);
            var isCreateDb = await dbContext.Database.EnsureCreatedAsync();

            if (isCreateDb) ;
            //логика
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

        public void GetAllCredential()
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
