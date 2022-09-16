public interface ITelegramBotSettings
{
    string AccessToken { get; set; }
}

public interface ITelegramBotService : IDisposable
{
    Task SayHelloAsync();
}
