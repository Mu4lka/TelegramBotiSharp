using Telegram.Bot;
using Telegram.Bot.Types.Payments;
using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Types.Contexts;

public class PreCheckoutQueryContext(
    ITelegramBotClient bot,
    CancellationToken cancellationToken,
    PreCheckoutQuery preCheckoutQuery
    ) : Context(bot, cancellationToken, preCheckoutQuery.From.Id, preCheckoutQuery.InvoicePayload)
{
    public PreCheckoutQuery PreCheckoutQuery { get; set; } = preCheckoutQuery;
}
