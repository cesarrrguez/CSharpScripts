public interface ITelegramBotSettings
{
    string AccessToken { get; set; }
}

public interface ITelegramBotService : IDisposable
{
    void SayHello();
}
