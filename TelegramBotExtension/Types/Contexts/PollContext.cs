using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Types.Contexts;

public class PollContext(
    ITelegramBotClient bot,
    CancellationToken cancellationToken,
    Poll poll
    ) : BaseContext(bot, cancellationToken)
{
    public Poll Poll { get; set; } = poll;
}
