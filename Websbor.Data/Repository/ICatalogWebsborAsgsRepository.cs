using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Websbor.Data.Model;

namespace Websbor.Data.Repository
{
    public interface ICatalogWebsborAsgsRepository
    {
        Task<List<CatalogWebsborAsgs>> GetAllCatalogAsync();
        Task<CatalogWebsborAsgs>? GetCatalogByOkpoAsync(string okpo);
        Task<List<CatalogWebsborAsgs>> GetCatalogByLikeOkpoAsync(string okpo);
        Task<List<CatalogWebsborAsgs>> GetCatalogByNameAsync(string name);
        Task<CatalogWebsborAsgs?> GetCatalogByIdAsync(int id);
        Task<int> GetCountCatalogAsync();
        Task<List<CatalogWebsborAsgs>> GetCatalogByNameAndOkpoAsync(string name, string okpo);
        Task<List<CatalogWebsborAsgs>> GetCatalogByWhere(Expression<Func<CatalogWebsborAsgs, bool>> predicate);
        Task<int> GetIdByOkpoAsync(string okpo);
        Task SaveCatalogAsync(CatalogWebsborAsgs catalog);
        Task SaveCatalogAsync(List<CatalogWebsborAsgs> catalogs);
        Task DeleteCatalogAsync(int id);
        Task DeleteCatalogAsync(CatalogWebsborAsgs catalog);
        Task UpdateCatalogAsync(CatalogWebsborAsgs catalog);
        Task<List<CatalogWebsborAsgs>> SelectFromCatalog(string sqlSelectQuery, SqlParameter sqlParameter);
        Task<int> DeleteAllCatalog();
        Task<int> UpdateCatalogAsync(Expression<Func<SetPropertyCalls<CatalogWebsborAsgs>, SetPropertyCalls<CatalogWebsborAsgs>>> expression);
    }
}
