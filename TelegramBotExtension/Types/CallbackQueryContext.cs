using Telegram.Bot.Types;
using Telegram.Bot;

namespace TelegramBotExtension.Types
{
    public class CallbackQueryContext : Context
    {
        public CallbackQuery CallbackQuery;

        public CallbackQueryContext(
            ITelegramBotClient bot,
            CancellationToken cancellationToken,
            CallbackQuery callbackQuery
            ) : base(bot, cancellationToken, callbackQuery.From.Id, callbackQuery.Data!)
        {
            CallbackQuery = callbackQuery;
        }

    }

}
