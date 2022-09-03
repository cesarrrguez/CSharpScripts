using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;

public static class TwilioService
{
    private const string ACCOUNT_SID = "XXXXXXXXX";
    private const string AUTH_TOKEN = "XXXXXXXXX";
    private const string PHONE_NUMBER = "XXXXXXXXX";
    private const string SANDBOX_PHONE_NUMBER = "XXXXXXXXX";
    private const string SANDBOX_WHATSAPP_NUMBER = "XXXXXXXXX";

    public static async Task SendSmsAsync()
    {
        TwilioClient.Init(ACCOUNT_SID, AUTH_TOKEN);

        try
        {
            var message = await MessageResource.CreateAsync(
                    body: "Hey there! I'm using Twilio",
                    from: new Twilio.Types.PhoneNumber(SANDBOX_PHONE_NUMBER),
                    to: new Twilio.Types.PhoneNumber(PHONE_NUMBER)
                );

            WriteLine(message.Sid);
        }
        catch (ApiException e)
        {
            WriteLine(e.Message);
            WriteLine($"Twilio Error {e.Code} - {e.MoreInfo}");
        }
    }

    public static async Task SendWhatsAppAsync()
    {
        TwilioClient.Init(ACCOUNT_SID, AUTH_TOKEN);

        try
        {
            var message = await MessageResource.CreateAsync(
                    body: "Hey there! I'm using Twilio",
                    from: new Twilio.Types.PhoneNumber($"whatsapp:{SANDBOX_WHATSAPP_NUMBER}"),
                    to: new Twilio.Types.PhoneNumber($"whatsapp:{PHONE_NUMBER}"),
                    mediaUrl: new List<Uri> { new Uri("https://cesarrrguez.github.io/assets/img/photo.jpg") }
                );

            WriteLine(message.Sid);
        }
        catch (ApiException e)
        {
            WriteLine(e.Message);
            WriteLine($"Twilio Error {e.Code} - {e.MoreInfo}");
        }
    }

    public static async Task MakeCallAsync()
    {
        TwilioClient.Init(ACCOUNT_SID, AUTH_TOKEN);

        try
        {
            var call = await CallResource.CreateAsync(
                url: new Uri("http://demo.twilio.com/docs/voice.xml"),
                from: new Twilio.Types.PhoneNumber(SANDBOX_PHONE_NUMBER),
                to: new Twilio.Types.PhoneNumber(PHONE_NUMBER)
            );

            WriteLine(call.Sid);
        }
        catch (ApiException e)
        {
            WriteLine(e.Message);
            WriteLine($"Twilio Error {e.Code} - {e.MoreInfo}");
        }
    }
}
