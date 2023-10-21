using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.RespondentsCredentials.Services.GeneratorSqlExpression
{
    public interface IGeneratorSqlExpression
    {
        string GetSelectExpression();
        string GetInsertExpression();
        string GetUpdateExpression();
        string GetDeleteExpression();
    }
}
