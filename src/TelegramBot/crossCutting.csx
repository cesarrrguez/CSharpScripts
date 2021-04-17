#load "settings.csx"
#load "interfaces.csx"
#load "services.csx"

using Telegram.Bot;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

public static class IoC
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<ITelegramBotSettings>(sp =>
           sp.GetRequiredService<IOptions<TelegramBotSettings>>().Value);

        services.AddScoped<ITelegramBotClient>(sp =>
            new TelegramBotClient(sp.GetRequiredService<ITelegramBotSettings>().AccessToken));

        services.AddScoped<ITelegramBotService, TelegramBotService>();
    }
}
