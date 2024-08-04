namespace UnitTestConsoleApp;

public class UserAccount
{
    private readonly IEmailService _emailService;
    private string _email;

    public UserAccount(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public bool SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be null or empty");
        }

        _email = email;

        return _emailService.SendEmail(_email, "Welcome", "Thank you for registering.");
    }

    public bool SetEmailWithAttachment(string email, string subject, string body, string attachmentPath)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be null or empty");
        }

        _email = email;

        return _emailService.SendEmailWithAttachment(_email, subject, body, attachmentPath);
    }

    public string GetEmail()
    {
        return _email;
    }
}

public interface IEmailService
{
    bool SendEmail(string email, string subject, string body);
    bool SendEmailWithAttachment(string email, string subject, string body, string attachmentPath);
}

public class EmailService : IEmailService
{
    public bool SendEmail(string email, string subject, string body)
    {
        // Dummy logic for demonstration:
        if (string.IsNullOrEmpty(email)) return false;

        Console.WriteLine($"Sending email to {email} with subject '{subject}'");
        return true; // Assume the email was sent successfully
    }

    public bool SendEmailWithAttachment(string email, string subject, string body, string attachmentPath)
    {
        // Dummy logic for demonstration:
        if (string.IsNullOrEmpty(email)) return false;

        Console.WriteLine($"Sending email to {email} with attachment {attachmentPath}");
        return true; // Assume the email was sent successfully
    }
}

class Program
{
    static void Main(string[] args)
    {
        
    }
}