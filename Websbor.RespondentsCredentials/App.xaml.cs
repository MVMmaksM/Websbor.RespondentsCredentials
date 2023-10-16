using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Websbor.Data;
using Websbor.RespondentsCredentials.AppFacade;
using Websbor.RespondentsCredentials.Services;

namespace Websbor.RespondentsCredentials
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<WebsborContext>(options =>
            {
                options.UseSqlServer("Data Source = Employee.db");
            });

            services.AddSingleton<MainWindow>();
            services.AddSingleton<IAppFacade, AppFacade.AppFacade>();
            services.AddSingleton<IMessageService, MessageService>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
