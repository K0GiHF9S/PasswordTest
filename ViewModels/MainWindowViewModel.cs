using PasswordTest.Models;
using System.IO;

namespace PasswordTest.ViewModels;

public class MainWindowViewModel
{
    public MainWindowViewModel(IPresentationService presentationService)
    {
		try
        {
            var encrypted = File.ReadAllText("login.info");
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
