using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Types.Contexts;

public class CallbackQueryContext(
    ITelegramBotClient bot,
    CancellationToken cancellationToken,
    CallbackQuery callbackQuery
    ) : Context(bot, cancellationToken, callbackQuery.From.Id, callbackQuery.Data)
{
    public CallbackQuery CallbackQuery { get; set; } = callbackQuery;
}
