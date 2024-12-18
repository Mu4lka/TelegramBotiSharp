﻿using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.Message"/> handler
/// </summary>
public abstract class MessageHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.Message;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => builder
            .WithUser(u => u.Message!.From!)
            .WithData(u => u.Message!.Text)
            .WithUserStorageItem(u => u.Message!.From!.Id)
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
