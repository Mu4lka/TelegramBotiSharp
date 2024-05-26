using TelegramBotExtension.Types;

namespace TelegramBotExtension.Handling.Handlers
{
    public abstract class CallbackQueryHandler : IHandler
    {
        public abstract Task HandleCallbackQuery(CallbackQueryContext context);

    }

}
