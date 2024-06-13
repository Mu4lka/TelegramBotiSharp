using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Types.Contexts;

public class InlineQueryContext(
    ITelegramBotClient bot,
    CancellationToken cancellationToken,
    InlineQuery inlineQuery
    ) : Context(bot, cancellationToken, inlineQuery.From.Id, inlineQuery.Query)
{
    public InlineQuery InlineQuery { get; set; } = inlineQuery;
}
