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
    public interface ICredentialsRepository
    {
        Task<List<Credentials>> GetAllCredentialsAsync();
        Task<List<Credentials>> GetCredentialByOkpoAsync(string okpo);
        Task<List<Credentials>> GetCredentialByNameAsync(string name);
        Task<Credentials?> GetCredentialByIdAsync(int id);
        Task<List<Credentials>> GetCredentialByNameAndOkpoAsync(string name, string okpo);
        Task<List<Credentials>> GetCredentiaslByWhere(Expression<Func<Credentials, bool>> predicate);
        Task<int> GetIdByOkpoAsync(string okpo);
        Task<int> GetCountCredentialsAsync();
        Task SaveCredentialAsync(Credentials credential);
        Task SaveCredentialAsync(List<Credentials> credentials);
        Task DeleteCredentialAsync(int id);
        Task DeleteCredentialAsync(Credentials credential);
        Task UpdateCredentialAsync(Credentials credential);
        Task<List<Credentials>> SelectFromCredential(string sqlSelectQuery, SqlParameter sqlParameter);
        Task<int> DeleteAllCredential();
        Task<int> UpdateCredentialAsync(Expression<Func<SetPropertyCalls<Credentials>, SetPropertyCalls<Credentials>>> expression);
    }
}
