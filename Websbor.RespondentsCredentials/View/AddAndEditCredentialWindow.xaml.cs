using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
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
using Websbor.RespondentsCredentials.Prototype;
using Websbor.RespondentsCredentials.Services;
using Websbor.RespondentsCredentials.Services.Logger;

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
        private readonly ILoggerService _loggerService;
        private readonly Credentials? _updateCredential;
        private readonly Credentials? _tempUpdateCredential;
        private readonly Credentials? _addCredential;
        public AddAndEditCredentialWindow(ILoggerService loggerService, ICatalogWebsborAsgsRepository catalogRepository, IMessageService messageService, ICredentialsRepository credentialRepository, Credentials? updateCredential = null)
        {
            InitializeComponent();
            _credentialRepository = credentialRepository;
            _messageService = messageService;
            _loggerService = loggerService;

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
                _tempUpdateCredential = Prototype<Credentials>.GetPrototype(updateCredential);
                _catalogRepository = catalogRepository;
                this.DataContext = _tempUpdateCredential;
            }
        }

        private async void BtnSaveCredential_Click(object sender, RoutedEventArgs e)
        {
            if (_addCredential is not null)
            {
                try
                {
                    _loggerService.Info("Добавление записи в таблицу учетных данных респондентов");

                    await _credentialRepository.SaveCredentialAsync(_addCredential);
                    _messageService.Info("Запись успешно добавлена в базу данных!");
                }
                catch (Exception ex)
                {
                    _messageService.Error(ex.Message);
                    _loggerService.Error($"{ex.Message}\n{ex.StackTrace}");
                }
            }
            else
            {
                try
                {
                    _loggerService.Info("Обновление записи в таблице учетных данных респондентов");

                    Prototype<Credentials>.SetValueProperties(_updateCredential, _tempUpdateCredential);

                    _updateCredential.DateUpdate = DateTime.Now;
                    await _credentialRepository.UpdateCredentialAsync(_updateCredential);
                    _messageService.Info("Запись успешно обновлена в базе данных!");
                }
                catch (Exception ex)
                {
                    _messageService.Error(ex.Message);
                    _loggerService.Error($"{ex.Message}\n{ex.StackTrace}");
                }
            }
        }

        private async void TxtBxOkpo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_addCredential is not null)
            {
                try
                {
                    _loggerService.Info("Подгрузка данных из каталога Web-сбора для добавления в таблицу учетных данных");
                    _addCredential.CatalogWebsborAsgs = await _catalogRepository.GetCatalogByOkpoAsync(TxtBxOkpoCredential.Text);
                }
                catch (Exception ex)
                {
                    _messageService.Error(ex.Message);
                    _loggerService.Error($"{ex.Message}\n{ex.StackTrace}");
                }
            }
            else if (_tempUpdateCredential is not null)
            {
                try
                {
                    _loggerService.Info("Подгрузка данных из каталога Web-сбора при обновлении учетных данных");
                    _tempUpdateCredential.CatalogWebsborAsgs = await _catalogRepository.GetCatalogByOkpoAsync(TxtBxOkpoCredential.Text);
                }
                catch (Exception ex)
                {
                    _messageService.Error(ex.Message);
                    _loggerService.Error($"{ex.Message}\n{ex.StackTrace}");
                }
            }
        }
    }
}
