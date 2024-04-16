using System.Text.RegularExpressions;

namespace BoraRachar.Domain.Utils;

public class Validators
{
    public static bool ValidatePassword(string pass)
    {
        string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\W).+$";

        return Regex.IsMatch(pass, pattern);
    }
}
