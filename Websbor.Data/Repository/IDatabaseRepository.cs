using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.Data.Repository
{
    public interface IDatabaseRepository
    {
        Task<int> ExecuteSqlQueryAync(string sqlQuery, params object[] parameters);
    }
}
