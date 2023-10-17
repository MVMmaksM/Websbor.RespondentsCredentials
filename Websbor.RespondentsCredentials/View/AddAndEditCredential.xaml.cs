using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Websbor.Data.Model;
using Websbor.Data.Repository;
using Websbor.RespondentsCredentials.Services;

namespace Websbor.RespondentsCredentials.View
{
    /// <summary>
    /// Логика взаимодействия для AddAndEditCredential.xaml
    /// </summary>
    public partial class AddAndEditCredential : Window
    {
        private readonly IMessageService _messageService;
        private readonly ICredentialsRepository _credentialRepository;
        private readonly Credentials _credential;
        public AddAndEditCredential(IMessageService messageService, ICredentialsRepository credentialRepository, Credentials credential)
        {
            InitializeComponent();
            _credentialRepository = credentialRepository;
            _credential = credential;
            this.DataContext = _credential;
            _messageService = messageService;
        }

        private void BtnSaveCredential_Click(object sender, RoutedEventArgs e)
        {
            _credentialRepository.UpdateCredentialAsync(_credential);
            _messageService.Info("Изменения успешно сохранены");
        }
    }
}
