namespace UnitTestConsoleApp;

public class UserAccount
{
    private string _email;

    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be null or empty");
        }

        _email = email;
    }

    public string GetEmail()
    {
        return _email;
    }
}

class Program
{
    static void Main(string[] args)
    {
        
    }
}