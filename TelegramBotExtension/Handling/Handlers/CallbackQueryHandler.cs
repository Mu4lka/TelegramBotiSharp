using TelegramBotExtension.Types;

namespace TelegramBotExtension.Handling.Handlers
{
    public abstract class CallbackQueryHandler : IHandler
    {
        public async Task Execute(Context context)
        {
            await Handle((CallbackQueryContext)context);
        }

        public abstract Task Handle(CallbackQueryContext context);

    }

}
