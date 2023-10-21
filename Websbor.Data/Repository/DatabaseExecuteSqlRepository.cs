using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public async Task<DataTable> ExecuteSqlQueryAsync(string connectionString, string sqlExpression)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                DataTable dtResultQuery = null;
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                SqlDataReader sqlReader = await sqlCommand.ExecuteReaderAsync();

                if (sqlReader.HasRows) // если есть данные
                {
                    var countColumn = sqlReader.FieldCount;
                    dtResultQuery = new DataTable();

                    for (int i = 0; i < countColumn; i++)
                    {
                        var newColumn = new DataColumn();
                        newColumn.ColumnName = sqlReader.GetName(i);
                        dtResultQuery.Columns.Add(newColumn);
                    }

                    while (await sqlReader.ReadAsync()) // построчно считываем данные
                    {
                        var newRow = dtResultQuery.NewRow();

                        for (int i = 0; i < countColumn; i++)
                        {
                            newRow[i] = sqlReader.GetValue(i);
                        }

                        dtResultQuery.Rows.Add(newRow);
                    }
                }
                else
                {
                    dtResultQuery = new DataTable();
                    dtResultQuery.Columns.Add(new DataColumn("Result"));
                    var newRow = dtResultQuery.NewRow();
                    newRow[0] = sqlReader.RecordsAffected;
                    dtResultQuery.Rows.Add(newRow);
                }

                await sqlReader.CloseAsync();
                return dtResultQuery;
            }
        }
    }
}
