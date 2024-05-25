using Telegram.Bot.Types;
using Telegram.Bot;

namespace TelegramBotExtension.Types
{
    public class MessageContext : Context
    {
        public Message Message;

        public MessageContext(
            ITelegramBotClient bot,
            CancellationToken cancellationToken,
            Message message
            ) : base(bot, cancellationToken, message.From!.Id, message.Text!)
        {
            Message = message;
        }

    }

}
