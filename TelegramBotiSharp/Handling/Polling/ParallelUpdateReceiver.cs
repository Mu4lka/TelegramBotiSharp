﻿using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace TelegramBotiSharp.Handling.Polling;

public class ParallelUpdateReceiver : IUpdateReceiver
{
    private readonly ITelegramBotClient _botClient;
    private readonly ReceiverOptions _receiverOptions;

    public ParallelUpdateReceiver(
        ITelegramBotClient botclient,
        ReceiverOptions receiverOptions = default!)
    {
        _botClient = botclient ?? throw new ArgumentNullException(nameof(botclient));
        _receiverOptions = receiverOptions ?? new ReceiverOptions();
    }

    public async Task ReceiveAsync(IUpdateHandler updateHandler, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(updateHandler);

        while (!cancellationToken.IsCancellationRequested)
        {
            var timeout = (int)_botClient.Timeout.TotalSeconds;
            Update[]? updates = null;
            try
            {
                updates = await _botClient.GetUpdatesAsync(
                    offset: _receiverOptions.Offset,
                    limit: _receiverOptions.Limit,
                    timeout: timeout,
                    allowedUpdates: _receiverOptions.AllowedUpdates,
                    cancellationToken: cancellationToken
                );
            }
            catch
            {
                throw;
            }

            if (updates is null)
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
                await updateHandler.HandlePollingErrorAsync(_botClient, task.Exception!, cancellationToken);
            }
        }
    }
}