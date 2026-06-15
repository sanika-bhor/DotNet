using MailKit.Net.Smtp;
using MimeKit;

public class EmailService:IEmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public void SendEmail(string toEmail, string password)
    {
        var email = new MimeMessage();


        string emailby = _config["EmailService:email"];
        string emailpassword = _config["EmailService:password"];
        string host = _config["EmailService:host"];
        int port = int.Parse(_config["EmailService:port"]);

        email.From.Add(MailboxAddress.Parse(emailby));
        email.To.Add(MailboxAddress.Parse(toEmail));
        email.Subject = "password Verification";



        email.Body = new TextPart(MimeKit.Text.TextFormat.Text)
        {
            Text = $"Your password is: {password}"
        };

    using var smtp = new SmtpClient();
        smtp.Connect(
            host,
           port,
            false
        );

        smtp.Authenticate(
            emailby,
            emailpassword
        );

        smtp.Send(email);
        smtp.Disconnect(true);
    }
}

// dotnet user-secrets init
// dotnet user-secrets set "EmailService:port" "587" for(TSL)
// dotnet user-secrets set "EmailService:password" "your password"

        // Step 1: Turn ON 2-Step Verification
        // Step 2: Open App Passwords
        // Step 3: Create Password
        // Step 4: Copy the 16-character Password

// dotnet user-secrets set "EmailService:host" "smtp.gmail.com"
// dotnet user-secrets set "EmailService:email" "your email"
// dotnet user-secrets list
