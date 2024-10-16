﻿using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.CallbackQuery"/> handler
/// </summary>
public abstract class CallbackQueryHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.CallbackQuery;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => new(
            builder.BotClient,
            builder.Storage,
            builder.Update,
            builder.Update.CallbackQuery!.From,
            builder.Update.CallbackQuery!.Data,
            builder.Token);

    public abstract Task HandleAsync(TelegramContext context);
}
