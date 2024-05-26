using TelegramBotExtension.Types;
using TelegramBotExtension.Types.Base;

namespace TelegramBotExtension.Handling.Handlers
{
    public abstract class MessageHandler : IHandler
    {
        public async Task Execute(Context context)
        {
            await Handle((MessageContext)context);
        }

        public abstract Task Handle(MessageContext context);

    }

}
