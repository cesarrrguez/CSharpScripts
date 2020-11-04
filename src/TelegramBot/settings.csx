#load "interfaces.csx"

public class TelegramBotSettings : ITelegramBotSettings
{
    public string AccessToken { get; set; }
}
