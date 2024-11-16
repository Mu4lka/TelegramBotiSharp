using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;

namespace TelegramBotiSharp.Extensions;

public static class ITelegramBotClientExtensions
{
    /// <summary>
    /// Start receiving <see cref="Update"/> and begin processing through
    /// <see cref="IUpdateHandler.HandleUpdateAsync"/>
    /// </summary>
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
                DropPendingUpdates = options.DropPendingUpdates
            });

        await receiver.ReceiveAsync(updateHandler, token);
    }
}
