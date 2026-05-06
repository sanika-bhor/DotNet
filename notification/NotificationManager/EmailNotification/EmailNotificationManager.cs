using backend.Settings;
using backend.Helpers;
using Microsoft.Extensions.Options;
using backend.Services;
namespace backend.EmailNotificationManager;

using System.Net;
using System.Net.Mail;

public class EmailNotificationManager : INotificationManager
{
    private readonly EmailSettings _emailSettings;

    public EmailNotificationManager(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }


    public async Task SendMessageAsync(string to, string subject, string content)
    {
        if (string.IsNullOrWhiteSpace(to))
            throw new ArgumentException("Recipient email cannot be empty");

        string htmlBody = $@"
<html>
<body style='font-family: Arial, sans-serif; background-color:#f4f4f4; padding:20px;'>
    <div style='max-width:600px; margin:auto; background:white; padding:20px; border-radius:10px;'>
        
        <h2 style='color:#333;'>🔐 Password Verification</h2>
        
        <p>Hello,</p>
        
        <p>Your verification password is:</p>
        
        <h1 style='color:#007bff; text-align:center;'>{content}</h1>
        
        <p>This password will expire soon. Please do not share it with anyone.</p>
        
        <hr />
        
        <p style='font-size:12px; color:gray;'>
            If you didn’t request this, please ignore this email.
        </p>
        
        <p style='font-size:12px; color:gray;'>— Your Team</p>
    </div>
</body>
</html>";


        using (var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.Port))
        {
            client.Credentials = new NetworkCredential(
                _emailSettings.Username,
                _emailSettings.Password);

            client.EnableSsl = _emailSettings.EnableSsl;

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
                Subject = subject,
                Body = htmlBody,
                IsBodyHtml = true
            };

            mailMessage.To.Add(to);

            try
            {
                await client.SendMailAsync(mailMessage);
                JsonLogger.Log(new EmailLog
                {
                    To = to,
                    Subject = subject,
                    Message = content,
                    Status = "Success",
                    Timestamp = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                JsonLogger.Log(new EmailLog
                {
                    To = to,
                    Subject = subject,
                    Message = content,
                    Status = "Failed",
                    Timestamp = DateTime.Now
                });
                Console.WriteLine(ex.ToString());
            }
        }
    }
}