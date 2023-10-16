using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.Data.Repository
{
    public interface IDatabaseExecuteSqlRepository
    {
        Task<int> ExecuteSqlQueryAsync(string sqlQuery, params object[] parameters);
        Task<int> ExecuteSqlQueryAsync(string sqlQuery);
    }
}
