using TelegramBotExtension.Types;

namespace TelegramBotExtension.Handling.Handlers
{
    public abstract class MessageHandler
    {
        public abstract Task HandleMessage(MessageContext context);
    }
}
