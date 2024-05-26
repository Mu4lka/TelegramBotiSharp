using TelegramBotExtension.Types;

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
