using TelegramBotExtension.Types;
using TelegramBotExtension.Types.Base;

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
