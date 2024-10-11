using Telegram.Bot;
using Telegram.Bot.Polling;

namespace TelegramBotiSharp.Extensions;

public static class ITelegramBotClientExtensions
{
    public static async Task StartReceivingAsync(
        this ITelegramBotClient botClient,
        IUpdateHandler updateHandler,
        IUpdateReceiver receiver = default!,
        Handling.Polling.ReceiverOptions options = default!,
        CancellationToken token = default!
        )
    {
        ArgumentNullException.ThrowIfNull(updateHandler);

        receiver ??= new DefaultUpdateReceiver(
            botClient,
            options is null ? null
            : new ReceiverOptions()
            {

                Limit = options.Limit,
                Offset = options.Offset,
                AllowedUpdates = options.AllowedUpdates,
                ThrowPendingUpdates = options.ThrowPendingUpdates
            });

        await receiver.ReceiveAsync(updateHandler, token);
    }
}
