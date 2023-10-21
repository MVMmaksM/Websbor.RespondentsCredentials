using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.RespondentsCredentials.Services.GeneratorSqlExpression
{
    public class GeneratorSqlExpression : IGeneratorSqlExpression
    {
        public string GetDeleteExpression()
        {
            return @"DELETE
            FROM [dbo].[TableName]
            WHERE ";
        }

        public string GetInsertExpression()
        {
            return @"INSERT INTO [dbo].[TableName] ([column1],[column2],[column3])
            VALUES(value1, value2, value3)";
        }

        public string GetSelectExpression()
        {
            return @"SELECT [column1], [column2], [column3]
            FROM [dbo].[TableName]
            WHERE 
            GROUP BY
            HAVING
            ORDER BY";
        }

        public string GetUpdateExpression()
        {
            return @"UPDATE [dbo].[TableName]
            SET [column] = value
            WHERE";
        }
    }
}
