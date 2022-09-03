#load "interfaces.csx"
#load "entities.csx"

using Microsoft.Extensions.Options;

public class EmailService : IEmailService
{
    private readonly EmailConfiguration _emailConfiguration;

    public EmailService(IOptions<EmailConfiguration> emailConfiguration)
    {
        _emailConfiguration = emailConfiguration.Value;
    }

    public async Task<bool> SendEmailAsync(string to, string subject, string body)
    {
        WriteLine($"Email configuration server: {_emailConfiguration.SmtpServer}, from: {_emailConfiguration.From}");
        WriteLine($"Email data to: {to}, subject {subject}, body {body}");

        await Task.Delay(TimeSpan.FromSeconds(1));

        return true;
    }
}
