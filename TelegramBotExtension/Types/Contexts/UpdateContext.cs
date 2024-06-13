using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Types.Contexts;

public class UpdateContext(
    ITelegramBotClient bot,
    CancellationToken cancellationToken,
    Update update
    ) : BaseContext(bot, cancellationToken)
{
    public Update Update { get; set; } = update;
}
