using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace TelegramBotiSharp.Handling.Polling;

/// <summary>
/// An implementation of <see cref="IUpdateReceiver"/> that requests new updates
/// and processes them in parallel in a non-deterministic manner.
/// </summary>
public class ParallelUpdateReceiver : IUpdateReceiver
{
    private readonly ITelegramBotClient _botClient;
    private readonly ReceiverOptions _receiverOptions;

    public ParallelUpdateReceiver(
        ITelegramBotClient botclient,
        ReceiverOptions receiverOptions = default!)
    {
        _botClient = botclient ?? throw new ArgumentNullException(nameof(botclient));
        _receiverOptions = receiverOptions ?? ReceiverOptions.Default();
    }

    public async Task ReceiveAsync(IUpdateHandler updateHandler, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(updateHandler);
        var offset = _receiverOptions.Offset;

        if (_receiverOptions.DropPendingUpdates is true)
        {
            var updates = await _botClient.GetUpdates(-1, 1, 0, [], cancellationToken);
            offset = updates.Length == 0 ? 0 : updates[^1].Id + 1;
        }

        while (!cancellationToken.IsCancellationRequested)
        {
            var timeout = (int)_botClient.Timeout.TotalSeconds;
            Update[]? updates = null;

            updates = await _botClient.GetUpdates(
                offset: offset,
                limit: _receiverOptions.Limit,
                timeout: timeout,
                allowedUpdates: _receiverOptions.AllowedUpdates,
                cancellationToken: cancellationToken
            );

            if (updates.Length == 0)
                continue;

            var tasks = updates.Select(
                update => updateHandler.HandleUpdateAsync(
                    _botClient,
                    update,
                    cancellationToken));

            var task = Task.WhenAll(tasks);
            try
            {
                await task;
            }
            catch
            {
                await updateHandler.HandleErrorAsync(_botClient, task.Exception!, HandleErrorSource.HandleUpdateError, cancellationToken);
            }
            offset = updates[^1].Id + 1;
        }
    }
}
