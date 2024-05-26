using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotExtension.Types.Base;

namespace TelegramBotExtension.Types
{
    public class CallbackQueryContext : Context
    {
        public CallbackQuery CallbackQuery { get; set; }

        public CallbackQueryContext(
            ITelegramBotClient bot,
            CancellationToken cancellationToken,
            CallbackQuery callbackQuery
            ) : base(bot, cancellationToken, callbackQuery.From.Id, callbackQuery.Data)
        {
            CallbackQuery = callbackQuery;
        }

    }

}
