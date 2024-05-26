using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotExtension.Types.Base;

namespace TelegramBotExtension.Types
{
    public class MessageContext : Context
    {
        public Message Message { get; set; }

        public MessageContext(
            ITelegramBotClient bot,
            CancellationToken cancellationToken,
            Message message
            ) : base(bot, cancellationToken, message.From.Id, message.Text)
        {
            Message = message;
        }

    }

}
