using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.RespondentsCredentials.Services.Logger
{
    public interface ILoggerService
    {
        void Warning(string message);
        void Error(string message);
        void Info(string message);
        void OpenCurrentLogFile(string pathFile);
        void OpenDirectoryLogs(string pathDirectoryLogs);
        void DeleteAllLogs(string pathDirectoryLogs);
    }
}
