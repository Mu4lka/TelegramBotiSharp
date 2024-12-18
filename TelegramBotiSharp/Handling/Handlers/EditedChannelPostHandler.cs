﻿using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.EditedChannelPost"/> handler
/// </summary>
public abstract class EditedChannelPostHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.EditedChannelPost;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => builder
            .WithUser(u => u.EditedChannelPost!.From!)
            .WithData(u => u.EditedChannelPost!.Text!)
            .WithUserStorageItem(u => u.EditedChannelPost!.From!.Id)
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
