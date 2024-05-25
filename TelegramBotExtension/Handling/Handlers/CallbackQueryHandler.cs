using TelegramBotExtension.Types;

namespace TelegramBotExtension.Handling.Handlers
{
    public abstract class CallbackQueryHandler : Handler
    {
        public abstract Task HandleCallbackQuery(CallbackQueryContext context);

    }

}
