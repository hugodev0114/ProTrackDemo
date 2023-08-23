using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProTrackDemo.Core;
using ProTrackDemo.DbContexts;
using ProTrackDemo.MVVM.ViewModels;
using ProTrackDemo.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProTrackDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        private const string CONNECTION_STRING = "Data Source=protrack.db";
        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()

            });

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<RegisterTrainingViewModel>();
            services.AddSingleton<TrackTrainingViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, ViewModel>>(ServiceProvider => viewModelType => (ViewModel)ServiceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
            ProTrackDbContext dbContext = new ProTrackDbContext(options);

            dbContext.Database.Migrate();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();

            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
