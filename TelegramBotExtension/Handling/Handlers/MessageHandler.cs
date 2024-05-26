using TelegramBotExtension.Types;

namespace TelegramBotExtension.Handling.Handlers
{
    public abstract class MessageHandler : IHandler
    {
        public abstract Task HandleMessage(MessageContext context);

    }

}
