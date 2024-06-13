using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotExtension.Types.Base;

namespace TelegramBotExtension.Types
{
    public class CallbackQueryContext(
        ITelegramBotClient bot,
        CancellationToken cancellationToken,
        CallbackQuery callbackQuery
        ) : Context(bot, cancellationToken, callbackQuery.From.Id, callbackQuery.Data!)
    {
        public CallbackQuery CallbackQuery { get; set; } = callbackQuery;
    }
}
