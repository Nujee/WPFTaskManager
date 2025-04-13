using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using TaskManager.Services;
using TaskManager.ViewModels;

namespace TaskManager
{
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = new MainWindow
            {
                DataContext = ServiceProvider.GetRequiredService<TaskListViewModel>()
            };
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITaskService, TaskService>();
            services.AddSingleton<TaskListViewModel>();
        }
    }
}
