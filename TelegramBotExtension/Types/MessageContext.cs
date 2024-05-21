using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ) : base(bot, cancellationToken, message.From.Id)
        {
            Message = message;
        }

    }

}
