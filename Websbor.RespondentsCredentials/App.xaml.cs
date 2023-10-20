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
using Websbor.Data.Repository;
using Websbor.RespondentsCredentials.AppFacade;
using Websbor.RespondentsCredentials.Services;
using Websbor.RespondentsCredentials.Services.Logger;
using Websbor.RespondentsCredentials.ViewModel;

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
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=WebsborCredential;Trusted_Connection=True;Encrypt=false;Integrated Security=True;");
            });

            services.AddSingleton<MainWindow>();
            services.AddSingleton<ApplicationViewModel>();
            services.AddSingleton<IAppFacade, AppFacade.AppFacade>();
            services.AddSingleton<IMessageService, MessageService>();
            services.AddSingleton<ICredentialsRepository, CredentialRepository>();
            services.AddSingleton<ICatalogWebsborAsgsRepository, CatalogRepository>();
            services.AddSingleton<ILoggerService, LoggerService>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
