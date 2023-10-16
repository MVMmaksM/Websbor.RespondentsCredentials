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
    public interface ICredentialsRepository
    {
        /// <summary>
        /// получение всех записей
        /// </summary>
        Task<List<Credentials>> GetAllCredentialsAsync();

        /// <summary>
        /// получение записей по ОКПО
        /// </summary>    
        Task<List<Credentials>> GetCredentialByOkpoAsync(string okpo);

        /// <summary>
        /// получение записей по наименованию
        /// </summary>
        Task<List<Credentials>> GetCredentialByNameAsync(string name);

        /// <summary>
        /// получение записи по id
        /// </summary>
        Task<Credentials?> GetCredentialByIdAsync(int id);

        /// <summary>
        /// получение записи по наименованию и ОКПО
        /// </summary>
        Task<List<Credentials>> GetCredentialByNameAndOkpoAsync(string name, string okpo);

        /// <summary>
        /// получение записей по условию делегата
        /// </summary>
        Task<List<Credentials>> GetCredentiaslByWhere(Expression<Func<Credentials, bool>> predicate);

        /// <summary>
        /// получение id записи по ОКПО
        /// </summary>
        Task<int> GetIdByOkpoAsync(string okpo);

        /// <summary>
        /// получение количества записей
        /// </summary>
        Task<int> GetCountCredentialsAsync();

        /// <summary>
        /// добавление записи
        /// </summary>
        Task SaveCredentialAsync(Credentials credential);

        /// <summary>
        /// добавление записей
        /// </summary>
        Task SaveCredentialAsync(List<Credentials> credentials);

        /// <summary>
        /// удаление записи по id
        /// </summary>
        Task DeleteCredentialAsync(int id);

        /// <summary>
        /// удаление записи
        /// </summary>
        Task DeleteCredentialAsync(Credentials credential);

        /// <summary>
        /// обновление записи
        /// </summary>
        Task UpdateCredentialAsync(Credentials credential);

        /// <summary>
        /// выборка данных через sql-запрос с параметрами
        /// </summary>
        Task<List<Credentials>> SelectFromCredential(string sqlSelectQuery, SqlParameter sqlParameter);
    }
}
