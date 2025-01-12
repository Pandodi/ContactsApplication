using Business.Factories;
using Business.Interfaces;
using Business.Services;
using ContactsApp.Interfaces;
using ContactsApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IFileService, FileService>();
        services.AddSingleton<IContactService, ContactService>();
        services.AddSingleton<MenuDialogs>();
    })
    .Build();

var mainMenu = host.Services.GetRequiredService<MenuDialogs>();
mainMenu.ShowMainMenu();


