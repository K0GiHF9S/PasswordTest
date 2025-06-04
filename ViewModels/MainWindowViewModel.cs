using PasswordTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
