using Kamishibai;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PasswordTest;
using PasswordTest.ViewModels;
using PasswordTest.Views;

var builder = KamishibaiApplication<App, MainWindow>.CreateBuilder();

builder.Services.AddPresentation<MainWindow, MainWindowViewModel>();
builder.Services.AddPresentation<LoginView, LoginViewModel>();
builder.Services.AddPresentation<MainView, MainViewModel>();

builder.Services.AddSingleton<ISnackbarMessageQueue, SnackbarMessageQueue>();

var app = builder.Build();
await app.RunAsync();
