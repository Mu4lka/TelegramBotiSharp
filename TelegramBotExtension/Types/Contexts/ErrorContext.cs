using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Types.Contexts
{
    public class ErrorContext(
        ITelegramBotClient bot,
        CancellationToken cancellationToken,
        Exception exception
        ) : BaseContext(bot, cancellationToken)
    {
        public Exception Exception { get; set; } = exception;
    }
}
