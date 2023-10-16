using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.Data.Repository
{
    public class DatabaseExecuteSqlRepository : IDatabaseExecuteSqlRepository
    {
        private readonly WebsborContext _context;
        public DatabaseExecuteSqlRepository(WebsborContext context)
        {
            _context = context;
        }
        public async Task<int> ExecuteSqlQueryAsync(string sqlQuery, params object[] parameters)
            => await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

        public async Task<int> ExecuteSqlQueryAsync(string sqlQuery)
            => await _context.Database.ExecuteSqlRawAsync(sqlQuery);
    }
}
