using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
    public partial class AddAndEditCredentialWindow : Window
    {
        private readonly ICatalogWebsborAsgsRepository _catalogRepository;
        private readonly IMessageService _messageService;
        private readonly ICredentialsRepository _credentialRepository;
        private readonly Credentials? _updateCredential;
        private readonly Credentials? _addCredential;
        public AddAndEditCredentialWindow(ICatalogWebsborAsgsRepository catalogRepository, IMessageService messageService, ICredentialsRepository credentialRepository, Credentials? updateCredential = null)
        {
            InitializeComponent();
            _credentialRepository = credentialRepository;
            _messageService = messageService;

            if (updateCredential is null)
            {
                _addCredential = new Credentials()
                {
                    UserCreate = WindowsIdentity.GetCurrent().Name,
                    DateCreate = DateTime.Now,
                };
                _catalogRepository = catalogRepository;
                this.DataContext = _addCredential;
            }
            else
            {
                _updateCredential = updateCredential;
                this.DataContext = _updateCredential;
            }
        }

        private async void BtnSaveCredential_Click(object sender, RoutedEventArgs e)
        {
            if (_updateCredential is null)
            {
                try
                {
                    await _credentialRepository.SaveCredentialAsync(_addCredential);
                    _messageService.Info("Запись успешно добавлена!");
                }
                catch (Exception ex)
                {
                    _messageService.Error(ex.Message);
                }
            }
            else
            {
                try
                {
                    _updateCredential.DateUpdate = DateTime.Now;
                    await _credentialRepository.UpdateCredentialAsync(_updateCredential);
                    _messageService.Info("Запись успешно обновлена!");
                }
                catch (Exception ex)
                {
                    _messageService.Error(ex.Message);
                }
            }
        }

        private async void TxtBxOkpo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_addCredential is not null)
            {
                try
                {
                    _addCredential.CatalogWebsborAsgs = await _catalogRepository.GetCatalogByOkpoAsync(_addCredential.Okpo);
                }
                catch (Exception ex)
                {
                    _messageService.Error(ex.Message);
                }
            }
        }
    }
}
