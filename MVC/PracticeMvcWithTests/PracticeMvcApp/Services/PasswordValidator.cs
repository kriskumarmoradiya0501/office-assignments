namespace PracticeMvcApp.Services;

public class PasswordValidator
{
    public bool HasMinimumLength(string password)
    {
        return password.Length >= 8;
    }

    public bool HasCapitalLetter(string password)
    {
        return password.Any(char.IsUpper);
    }

    public bool HasNumber(string password)
    {
        return password.Any(char.IsDigit);
    }

    public bool IsValid(string password)
    {
        return HasMinimumLength(password)
            && HasCapitalLetter(password)
            && HasNumber(password);
    }
}
