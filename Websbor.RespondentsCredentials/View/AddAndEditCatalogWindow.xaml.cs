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
using Websbor.RespondentsCredentials.Prototype;
using Websbor.RespondentsCredentials.Services;
using Websbor.RespondentsCredentials.Services.Logger;

namespace Websbor.RespondentsCredentials.View
{
    /// <summary>
    /// Логика взаимодействия для AddAndEditCatalogWindow.xaml
    /// </summary>
    public partial class AddAndEditCatalogWindow : Window
    {
        private readonly CatalogWebsborAsgs? _addCatalog;
        private readonly CatalogWebsborAsgs? _updateCatalog;
        private readonly CatalogWebsborAsgs? _tempUpdateCatalog;
        private readonly ICatalogWebsborAsgsRepository _catalogRepository;
        private readonly IMessageService _messageService;
        private readonly ILoggerService _loggerService;
        public AddAndEditCatalogWindow(ILoggerService loggerService, IMessageService messageService, ICatalogWebsborAsgsRepository catalogRepository, CatalogWebsborAsgs updateCatalog = null)
        {
            InitializeComponent();
            _catalogRepository = catalogRepository;
            _messageService = messageService;
            _loggerService = loggerService;

            if (updateCatalog is null)
            {
                _addCatalog = new CatalogWebsborAsgs();
                this.DataContext = _addCatalog;
            }
            else
            {
                _updateCatalog = updateCatalog;
                _tempUpdateCatalog = Prototype<CatalogWebsborAsgs>.GetPrototype(updateCatalog);
                this.DataContext = _tempUpdateCatalog;
            }
        }

        private async void BtnSaveCatalog_Click(object sender, RoutedEventArgs e)
        {
            if (_addCatalog is not null)
            {
                try
                {
                    _loggerService.Info("Добавление записи в каталог Web-сбора");

                    await _catalogRepository.SaveCatalogAsync(_addCatalog);
                    _messageService.Info("Запись успешно добавлена!");
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
                    _loggerService.Info("Обновление записи в каталоге Web-сбора");

                    Prototype<CatalogWebsborAsgs>.SetValueProperties(_updateCatalog, _tempUpdateCatalog);
                    await _catalogRepository.UpdateCatalogAsync(_updateCatalog);
                    _messageService.Info("Запись успешно обновлена!");
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
