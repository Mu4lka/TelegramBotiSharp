using Telegram.Bot.Types.Enums;
using TelegramBotExtension.Types.Contexts;
using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Filters;

public class Command(string command) : FilterAttribute(command)
{
    private bool IsValidCommand(Context context)
    {
        if (context is not MessageContext messageContext)
            return false;

        var message = messageContext.Message;

        if (message.Entities == null || message.Entities.Length == 0)
            return false;

        if (message.Entities[0].Type != MessageEntityType.BotCommand)
            return false;

        return message.Text != null && message.Text == "/" + Data;
    }

    public override Task<bool> Call(Context context)
    {
        return Task.FromResult(IsValidCommand(context));
    }
}
