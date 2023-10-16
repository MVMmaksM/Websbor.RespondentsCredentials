using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.RespondentsCredentials.AppFacade
{
    public interface IAppFacade
    {
        void LoadCredential();
        void LoadCatalog();
        void SaveAllCredential();
        void SaveCurrentRowsCredential();
        void SaveAllCatalog();
        void SaveCurrentRowsCatalog();
        void ShemaLoadCredential();
        void ShemaLoadCatalog();
        void CreateDb();
        void ExecuteSqlQuery();
        void DeleteCredential();
        void DeleteCatalog();
        void OpenProtocol();
        void OpenDirectoryProtocol();
        void OpenCurrentLogFile();
        void OpenDirectoryLogs();
        void DeleteLogs();
        void AddCredential();
        void DeleteCredentialRow();
        void GetAllCredential();
        void EditCredential();
        void SearchCredential();
        void AddCatalog();
        void EditCatalog();
        void GetAllCatalog();
        void SearchCatalog();
        void DeleteCatalogRow();
    }
}
