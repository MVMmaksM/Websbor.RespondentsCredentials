using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websbor.Data.Model;

namespace Websbor.Data.Repository
{
    public interface ICatalogWebsborAsgsRepository
    {
        /// <summary>
        /// получение всех записей
        /// </summary>
        Task<List<CatalogWebsborAsgs>> GetAllCatalogAsync();

        /// <summary>
        /// получение записей по ОКПО
        /// </summary>
        Task<List<CatalogWebsborAsgs>> GetCatalogByOkpoAsync(string okpo);

        /// <summary>
        /// получение записей по наименованию
        /// </summary>>
        Task<List<CatalogWebsborAsgs>> GetCatalogByNameAsync(string name);

        /// <summary>
        /// получение записи по id
        /// </summary>
        Task<CatalogWebsborAsgs> GetCatalogByIdAsync(int id);

        /// <summary>
        /// получение количества записей
        /// </summary>
        Task<int> GetcountCatalogAsync();

        /// <summary>
        /// получение записей по ОКПО и наименованию
        /// </summary>
        Task<List<CatalogWebsborAsgs>> GetCatalogByNameAndOkpoAsync(string name, string okpo);

        /// <summary>
        /// получение записей по условию делегата
        /// </summary>
        Task<List<CatalogWebsborAsgs>> GetCatalogByWhere(Predicate<CatalogWebsborAsgs> predicate);

        /// <summary>
        /// получение id по ОКПО
        /// </summary>
        Task<int> GetIdByOkpoAsync(string okpo);

        /// <summary>
        /// добавление записи
        /// </summary>
        Task SaveCatalogAsync(CatalogWebsborAsgs catalog);

        /// <summary>
        /// добавление записей
        /// </summary>
        Task SaveCatalogAsync(List<CatalogWebsborAsgs> catalogs);

        /// <summary>
        /// удаление записи по id
        /// </summary>
        Task DeleteCatalogAsync(int id);

        /// <summary>
        /// удаление записи
        /// </summary>
        Task DeleteCatalogAsync(CatalogWebsborAsgs catalog);

        /// <summary>
        /// обновление записи
        /// </summary>
        Task UpdateCatalogAsync(CatalogWebsborAsgs catalog);

        /// <summary>
        /// получение записей с помощью параметризованного запроса
        /// </summary>
        Task<List<CatalogWebsborAsgs>> SelectFromCatalog(string sqlSelectQuery, SqlParameter sqlParameter);
    }
}
