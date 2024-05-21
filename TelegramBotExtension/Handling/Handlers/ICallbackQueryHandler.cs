using TelegramBotExtension.Types;

namespace TelegramBotExtension.Handling.Routers
{
    public interface ICallbackQueryHandler
    {
        Task HandleCallbackQuery(CallbackQueryContext context);

    }

}