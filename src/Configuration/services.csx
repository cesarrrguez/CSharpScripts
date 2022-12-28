#load "interfaces.csx"
#load "entities.csx"

public class EmailService : IEmailService
{
    private readonly EmailConfiguration _emailConfiguration;

    public EmailService(EmailConfiguration emailConfiguration)
    {
        _emailConfiguration = emailConfiguration;
    }

    public async Task<bool> SendEmailAsync(string to, string subject, string body)
    {
        WriteLine($"Email configuration server: {_emailConfiguration.SmtpServer}, from: {_emailConfiguration.From}");
        WriteLine($"Email data to: {to}, subject {subject}, body {body}");

        await Task.FromResult(0);

        return true;
    }
}
