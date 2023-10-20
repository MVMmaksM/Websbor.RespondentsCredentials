using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.RespondentsCredentials.Services.Logger
{
    public class LoggerService : ILoggerService
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();
        private readonly IMessageService _messageService;

        public LoggerService(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warning(string message)
        {
            _logger.Warn(message);
        }

        public void OpenCurrentLogFile(string pathFile)
        {
            OpenLog(pathFile);
        }

        public void OpenDirectoryLogs(string pathDirectoryLogs)
        {
            OpenLog(pathDirectoryLogs);
        }

        public void DeleteAllLogs(string pathDirectoryLogs)
        {
            if (_messageService.Question("Удалить все log-файлы?"))
            {
                try
                {
                    int countDeleteFile = 0;
                    var directiryInfo = new DirectoryInfo(pathDirectoryLogs);

                    foreach (FileInfo logFile in directiryInfo.EnumerateFiles())
                    {
                        logFile.Delete();
                        countDeleteFile++;
                    }

                    _messageService.Info($"Удалено log-файлов: {countDeleteFile}");
                }
                catch (Exception ex)
                {
                    _messageService.Error(ex.Message);
                    _logger.Error($"{ex.Message}\n{ex.StackTrace}");
                }
            }
        }

        private void OpenLog(string path)
        {
            try
            {

                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.UseShellExecute = true;
                processStartInfo.FileName = path;
                Process.Start(processStartInfo);
            }
            catch (Exception ex)
            {
                _messageService.Error(ex.Message);
                _logger.Error($"{ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}
