using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Types.Contexts;

public class MessageContext(
    ITelegramBotClient bot,
    CancellationToken cancellationToken,
    Message message
    ) : Context(bot, cancellationToken, message.From!.Id, message.Text)
{
    public Message Message { get; set; } = message;
}
