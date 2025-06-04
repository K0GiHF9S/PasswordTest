using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kamishibai;
using MaterialDesignThemes.Wpf;
using PasswordTest.Models;
using System.IO;

namespace PasswordTest.ViewModels;

[Navigate]
public partial class LoginViewModel([Inject] IPresentationService presentationService) : ObservableObject
{
    [ObservableProperty]
    private string password = "";

    [RelayCommand]
    private void Login()
    {
        var hash = Utils.HashPassword(Password);
        if (Utils.VerifyPassword(hash))
        {
            var encrypted = Utils.Encrypt(hash);
            File.WriteAllText("login.info", encrypted);
            presentationService.NavigateToMainAsync("LoginFrame");
        }
    }
}