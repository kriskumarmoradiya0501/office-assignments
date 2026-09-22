using MvcXunitDemo.Services;
public class PasswordValidator
{
    public bool IsValid(string password)
    {
        if(password == null || password.Length < 6)
        {
            return false;
        }

        bool hasCapital = false;
        bool hasNumber = false;

        foreach(char c in password)
        {
            if (char.IsUpper(c))
            {
                hasCapital = true;
            }
            if (char.IsDigit(c))
            {
                hasNumber = true;
            }
        }
        return hasCapital && hasNumber;
    }
}
