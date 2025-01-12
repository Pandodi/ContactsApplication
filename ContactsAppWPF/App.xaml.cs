using Business.Interfaces;
using Business.Services;
using ContactsAppWPF.ViewModels;
using ContactsAppWPF.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ContactsAppWPF
{

    public partial class App : Application
    {
        private IHost _host;
        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IFileService>(new FileService("contact.json"));
                    services.AddSingleton<IContactService, ContactService>();

                    services.AddTransient<MainMenuViewModel>();
                    services.AddTransient<ContactListViewModel>();
                    services.AddTransient<AddContactViewModel>();
                    services.AddTransient<ContactDetailsViewModel>();
                    services.AddTransient<EditContactViewModel>();

                    services.AddTransient<MainMenuView>();
                    services.AddTransient<ContactListView>();
                    services.AddTransient<AddContactView>();
                    services.AddTransient<ContactDetailsView>();
                    services.AddTransient<EditContactView>();

                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<MainWindow>();

                })
                .Build();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainViewModel = _host.Services.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _host.Services.GetRequiredService<MainMenuViewModel>();

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
