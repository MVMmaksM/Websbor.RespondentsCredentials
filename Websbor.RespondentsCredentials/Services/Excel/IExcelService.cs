using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websbor.Data.Model;

namespace Websbor.RespondentsCredentials.Services.Excel
{
    public interface IExcelService
    {
        List<CatalogWebsborAsgs> ReadExcelCatalog(string pathFile);
        byte[] GetExcelCatalog(List<CatalogWebsborAsgs> catalog);
        List<Credentials> ReadExcelCredential(string pathFile);
        byte[] GetExcelCredential (List<Credentials> credential);
        byte[] GetShemaLoadCredential();
        byte[] GetShemaLoadCatalog();
    }
}
