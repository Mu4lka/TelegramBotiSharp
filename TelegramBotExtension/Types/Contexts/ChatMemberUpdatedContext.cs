using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Types.Contexts;

public class ChatMemberUpdatedContext(
    ITelegramBotClient bot,
    CancellationToken cancellationToken,
    ChatMemberUpdated chatMemberUpdated
    ) : Context(bot, cancellationToken, chatMemberUpdated.From.Id, null)
{
    public ChatMemberUpdated ChatMemberUpdated { get; set; } = chatMemberUpdated;
}
