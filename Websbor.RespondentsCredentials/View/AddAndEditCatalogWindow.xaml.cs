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
    /// Логика взаимодействия для AddAndEditCatalogWindow.xaml
    /// </summary>
    public partial class AddAndEditCatalogWindow : Window
    {
        private readonly CatalogWebsborAsgs? _addCatalog;
        private readonly CatalogWebsborAsgs? _updateCatalog;
        private readonly ICatalogWebsborAsgsRepository _catalogRepository;
        private readonly IMessageService _messageService;
        public AddAndEditCatalogWindow(IMessageService messageService, ICatalogWebsborAsgsRepository catalogRepository, CatalogWebsborAsgs catalog = null)
        {
            InitializeComponent();
            _catalogRepository = catalogRepository;
            _messageService = messageService;

            if (catalog is null)
            {
                _addCatalog = new CatalogWebsborAsgs();
                this.DataContext = _addCatalog;
            }
            else
            {
                _updateCatalog = catalog;
                this.DataContext = _updateCatalog;
            }
        }

        private async void BtnSaveCatalog_Click(object sender, RoutedEventArgs e)
        {
            if (_addCatalog is not null)
            {
                try
                {
                    await _catalogRepository.SaveCatalogAsync(_addCatalog);
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
                    await _catalogRepository.UpdateCatalogAsync(_updateCatalog);
                    _messageService.Info("Запись успешно обновлена!");
                }
                catch (Exception ex)
                {
                    _messageService.Error(ex.Message);
                }
            }
        }
    }
}
