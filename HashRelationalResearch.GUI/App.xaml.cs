using HashRelationalResearch.GUI.Config;
using HashRelationalResearch.GUI.Services;
using HashRelationalResearch.GUI.Services.Interfaces;
using HashRelationalResearch.GUI.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
                .AddInMemoryCollection(GetDefaultConfiguration())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        private static Dictionary<string, string?> GetDefaultConfiguration()
        {
            var output = new Dictionary<string, string?>
            {
                { "DiscoveredHashesPath", "DiscoveredHashes" },
                { "PrcRootPath", "root" },
                { "HashDBFilePath", "db.bin" },
                { "HashcatFilePath", "Hashcat/hashcat.exe" }
            };
            return output;
        }

        private static IServiceCollection GetServices(IConfiguration configuration)
        {
            IServiceCollection services = new ServiceCollection();

            //Configuration
            services.Configure<AppConfiguration>(configuration);
            services.AddSingleton<IConfigurationService, ConfigurationService>();
            services.AddSingleton<IHashDBService, HashDBService>();
            services.AddSingleton<IDictionaryService, DictionaryService>();
            services.AddSingleton<IBruteForceHashService, BruteForceHashService>();
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<IHbtFileService, HbtFileService>();

            services.AddScoped<MainWindow>();
            services.AddScoped<MainWindowVM>();
            services.AddTransient<ResearchTabVM>();
            services.AddTransient<ResearchNroVM>();
            services.AddTransient<ResearchPrcVM>();
            services.AddTransient<HashCrackVM>();
            services.AddTransient<HashCrackDictionaryTabVM>();
            services.AddTransient<HashCrackCharacterTabVM>();
            services.AddTransient<HashCrackHybridTabVM>();

            return services;
        }
    }
}
