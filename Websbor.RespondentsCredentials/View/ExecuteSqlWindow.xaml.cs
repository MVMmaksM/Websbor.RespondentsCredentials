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
using Websbor.Data.Repository;
using Websbor.RespondentsCredentials.Model.ExecutedSqlModel;
using Websbor.RespondentsCredentials.Services;
using Websbor.RespondentsCredentials.Services.GeneratorSqlExpression;
using Websbor.RespondentsCredentials.Services.Logger;

namespace Websbor.RespondentsCredentials.View
{
    /// <summary>
    /// Логика взаимодействия для ExecuteSqlWindow.xaml
    /// </summary>
    public partial class ExecuteSqlWindow : Window
    {
        private readonly IMessageService _messageService;
        private readonly ILoggerService _loggerService;
        private readonly IDatabaseExecuteSqlRepository _executeSqlRepository;
        private readonly IGeneratorSqlExpression _generatorSqlExpression;
        private ExecutedSql _executedSql;
        public ExecuteSqlWindow(ExecutedSql executedSql, IGeneratorSqlExpression generatorSqlExpression,
            IDatabaseExecuteSqlRepository executeSqlRepository, ILoggerService loggerService, IMessageService messageService)
        {
            InitializeComponent();
            _generatorSqlExpression = generatorSqlExpression;
            _executedSql = executedSql;
            _executeSqlRepository = executeSqlRepository;
            _loggerService = loggerService;
            _messageService = messageService;
            this.DataContext = _executedSql;
        }

        private void CreateSelectQuery_Click(object sender, RoutedEventArgs e)
        {
            _executedSql.SqlExpression += $"{_generatorSqlExpression.GetSelectExpression()}\n\n";
        }

        private void CreateUpdateQuery_Click(object sender, RoutedEventArgs e)
        {
            _executedSql.SqlExpression += $"{_generatorSqlExpression.GetUpdateExpression()}\n\n";
        }
        private void CreateDeleteQuery_Click(object sender, RoutedEventArgs e)
        {
            _executedSql.SqlExpression += $"{_generatorSqlExpression.GetDeleteExpression()}\n\n";
        }
        private void CreateInsertQuery_Click(object sender, RoutedEventArgs e)
        {
            _executedSql.SqlExpression += $"{_generatorSqlExpression.GetInsertExpression()}\n\n";
        }

        private async void ExecuteSql_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_executedSql.SqlExpression) && !string.IsNullOrWhiteSpace(_executedSql.ConnectionString))
            {
                try
                {
                    var resultExecute = await _executeSqlRepository.ExecuteSqlQueryAsync(_executedSql.ConnectionString, _executedSql.SqlExpression);
                    DgResultExecuted.ItemsSource = resultExecute.DefaultView;
                }
                catch (Exception ex)
                {
                    _messageService.Error($"{ex.Message}");
                    _loggerService.Error($"{ex.Message}\n{ex.StackTrace}");
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TxtBxEditQuery.ScrollToEnd();
        }
    }
}
