using Kamishibai;
using Microsoft.Extensions.Hosting;
using PasswordTest;
using PasswordTest.Models;
using PasswordTest.ViewModels;
using PasswordTest.Views;

var builder = KamishibaiApplication<App, MainWindow>.CreateBuilder();

builder.Services.AddPresentation<MainWindow, MainWindowViewModel>();
builder.Services.AddPresentation<LoginView, LoginViewModel>();
builder.Services.AddPresentation<MainView, MainViewModel>();

var app = builder.Build();
await app.RunAsync();
