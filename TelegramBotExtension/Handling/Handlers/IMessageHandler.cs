using TelegramBotExtension.Types;

namespace TelegramBotExtension.Handling.Routers
{
    public interface IMessageHandler
    {
        Task HandleMessage(MessageContext context);

    }

}
