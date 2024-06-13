using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotExtension.Types.Base;

namespace TelegramBotExtension.Types;

public class MessageContext(
    ITelegramBotClient bot,
    CancellationToken cancellationToken,
    Message message
    ) : Context(bot, cancellationToken, message.From!.Id, message.Text!)
{
    public Message Message { get; set; } = message;
}
