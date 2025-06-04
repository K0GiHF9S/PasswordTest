using System.Security.Cryptography;

namespace PasswordTest.Models;

public class Utils
{
    private const string HasedBase64Password = "iCBzOoESr3R16kf60nrIjcXnR0hjL+UM5g+7NxlJlaiQK9BfbhVw33H5rdfTGs+8e1OGBQ+6l09CPW+egg9Rtw==";

    private const int IterateCount = 10000;
    private const int HashSize = 64;
    private const string Base64Salt = "8nmfqx7YwO24OATCIRdtHQ==";

    public static byte[] HashPassword(string inputPassword)
    {
        //var salt = new byte[16];
        //RandomNumberGenerator.Fill(salt);
        //var base64Salt = Convert.ToBase64String(salt);
        var salt = Convert.FromBase64String(Base64Salt);
        using var pbkdf2 = new Rfc2898DeriveBytes(inputPassword, salt, IterateCount, HashAlgorithmName.SHA512);
        var hash = pbkdf2.GetBytes(HashSize);
        return hash;
    }

    public static byte[] Encrypt(byte[] input)
    {
        var output = ProtectedData.Protect(input, null, DataProtectionScope.CurrentUser);
        return output;
    }

    public static byte[] Decrypt(byte[] input)
    {
        try
        {
            var output = ProtectedData.Unprotect(input, null, DataProtectionScope.CurrentUser);
            return output;
        }
        catch (Exception)
        {
            return [];
        }
    }

    public static bool VerifyPassword(byte[] hasedInput)
    {
        var hasedPassword = Convert.FromBase64String(HasedBase64Password);
        return hasedInput.SequenceEqual(hasedPassword);
    }
}
