using HashRelationalResearch.GUI.Config;
using HashRelationalResearch.GUI.Services;
using HashRelationalResearch.GUI.Services.Interfaces;
using HashRelationalResearch.GUI.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace HashRelationalResearch.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var configuration = GetConfiguration();
            var serviceProvider = GetServices(configuration)
                .BuildServiceProvider();

            var mainWindow = serviceProvider.GetService<MainWindow>();
            if (mainWindow != null)
            {
                //Load DB


                mainWindow.DataContext = serviceProvider.GetService<MainWindowVM>();
                mainWindow.Show();
            }
        }

        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        private static IServiceCollection GetServices(IConfiguration configuration)
        {
            IServiceCollection services = new ServiceCollection();

            //Configuration
            services.Configure<AppConfiguration>(configuration);
            services.AddSingleton<IConfigurationService, ConfigurationService>();
            services.AddSingleton<IHashDBService, HashDBService>();
            services.AddSingleton<IDictionaryService, DictionaryService>();

            services.AddScoped<MainWindow>();
            services.AddScoped<MainWindowVM>();
            services.AddTransient<ResearchTabVM>();
            services.AddTransient<ResearchNroVM>();
            services.AddTransient<ResearchPrcVM>();
            services.AddTransient<HashCrackVM>();
            services.AddTransient<HashCrackDictionaryTabVM>();

            return services;
        }
    }
}
