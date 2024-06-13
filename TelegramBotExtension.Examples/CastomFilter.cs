using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Types.Contexts;
using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Examples;

internal class CastomFilter() : FilterAttribute(null)
{
    public override async Task<bool> Call(Context context)
    {
        if (context is not MessageContext messageContext)
            return false;
        
        if (messageContext.Message.From == null)
            return false;

        User user = messageContext.Message.From;

        await context.Bot.SendTextMessageAsync(user.Id, "CastomFilter");
        return true;
    }
}
