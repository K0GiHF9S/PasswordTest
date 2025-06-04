using CommunityToolkit.Mvvm.ComponentModel;
using MaterialDesignThemes.Wpf;
using PasswordTest.Models;
using System.IO;

namespace PasswordTest.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private ISnackbarMessageQueue _messageQueue;

    public MainWindowViewModel(IPresentationService presentationService, ISnackbarMessageQueue messageQueue)
    {
        _messageQueue = messageQueue;

        try
        {
            var encrypted = File.ReadAllBytes("login.info");
            var hash = Utils.Decrypt(encrypted);
            if (Utils.VerifyPassword(hash))
            {
                presentationService.NavigateToMainAsync("LoginFrame");
                return;
            }
        }
        catch (Exception)
        {
        }
        presentationService.NavigateToLoginAsync("LoginFrame");
    }
}
