#load "interfaces.csx"

using Telegram.Bot;

public class TelegramBotService : ITelegramBotService
{
    private readonly ITelegramBotClient _client;

    public TelegramBotService(ITelegramBotClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));

        _client.OnMessage += OnMessage;
        _client.StartReceiving();
    }

    public async Task SayHelloAsync()
    {
        var me = await _client.GetMeAsync();

        WriteLine($"Hi, I am {me.Id} and my name is {me.FirstName}");
    }

    private async void OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
    {
        if (e.Message.Text != null)
        {
            WriteLine("Message received");

            if (e.Message.Text.Contains("message", StringComparison.OrdinalIgnoreCase))
            {
                await _client.SendTextMessageAsync(
                    chatId: e.Message.Chat.Id,
                    text: "This is a message"
                );
            }
            else if (e.Message.Text.Contains("sticker", StringComparison.OrdinalIgnoreCase))
            {
                await _client.SendStickerAsync(
                     chatId: e.Message.Chat.Id,
                     sticker: "https://s.tcdn.co/8a1/9aa/8a19aab4-98c0-37cb-a3d4-491cb94d7e12/1.png"
                );
            }
            else if (e.Message.Text.Contains("contact", StringComparison.OrdinalIgnoreCase))
            {
                await _client.SendContactAsync(
                    chatId: e.Message.Chat.Id,
                    phoneNumber: "+34123456789",
                    firstName: "John",
                    lastName: "Doe"
                );
            }
        }
    }

    public void Dispose()
    {
        if (_client.IsReceiving)
        {
            _client.StopReceiving();
        }

        GC.SuppressFinalize(this);
    }
}
