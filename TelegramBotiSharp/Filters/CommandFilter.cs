﻿using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Filters;

public class CommandFilter(string command) : FilterAttribute(command)
{
    private bool IsValidCommand(TelegramContext baseContext)
    {
        var message = baseContext.Update.Message;

        if (message == null)
            return false;

        if (message.Entities == null || message.Entities.Length == 0)
            return false;

        if (message.Entities[0].Type != MessageEntityType.BotCommand)
            return false;

        return message.Text != null && message.Text == "/" + Data;
    }

    public override Task<bool> CallAsync(TelegramContext context)
        => Task.FromResult(IsValidCommand(context));
}
