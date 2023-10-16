using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.RespondentsCredentials.Services
{
    internal interface IMessageService
    {
        void Info(string message);
        void Error(string message);
        void Warning(string message);
    }
}
