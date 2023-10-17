using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Websbor.RespondentsCredentials.Services
{
    public class MessageService : IMessageService
    {
        public void Error(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OKCancel, MessageBoxImage.Error);
        }

        public void Info(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButton.OKCancel, MessageBoxImage.Information);
        }

        public void Warning(string message)
        {
            MessageBox.Show(message, "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
        }
    }
}
