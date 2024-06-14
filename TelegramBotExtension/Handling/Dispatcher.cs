using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace TelegramBotExtension.Handling;

public class Dispatcher : Router, IUpdateHandler
{
    public List<Router> Routers;

    public Dispatcher() => Routers = [];

    public Dispatcher(List<Router> routers) => Routers = routers;

    public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var success = await TryHandleErrorAsync(botClient, exception, cancellationToken);

        foreach (var router in Routers)
        {
            if (success)
                return;
            success = await router.TryHandleErrorAsync(botClient, exception, cancellationToken);
        }
        if (!success)
            throw exception;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var success = await TryHandleRouterAsync(botClient, update, cancellationToken);

        foreach (var router in Routers)
        {
            if (success)
                return;
            success = await router.TryHandleRouterAsync(botClient, update, cancellationToken);
        }
    }
}
