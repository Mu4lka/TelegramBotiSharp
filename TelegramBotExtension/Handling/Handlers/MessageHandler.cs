using TelegramBotExtension.Types;

namespace TelegramBotExtension.Handling.Handlers
{
    public abstract class MessageHandler : Handler
    {
        public abstract Task HandleMessage(MessageContext context);

    }

}
