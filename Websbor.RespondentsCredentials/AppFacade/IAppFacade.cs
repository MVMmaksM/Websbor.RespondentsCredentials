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
        void AddCredential(MainWindow mainWindow);
        void DeleteCredentialRow();
        void GetAllCredential();
        void EditCredential(MainWindow mainWindow);
        void SearchCredential();
        void AddCatalog(MainWindow mainWindow);
        void EditCatalog(MainWindow mainWindow);
        void GetAllCatalog();
        void SearchCatalog();
        void DeleteCatalogRow();
    }
}
