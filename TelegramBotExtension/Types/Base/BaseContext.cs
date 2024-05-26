using Telegram.Bot;

namespace TelegramBotExtension.Types.Base
{
    public class BaseContext
    {
        public ITelegramBotClient Bot { get; set; }

        public CancellationToken CancellationToken { get; set; }

        public BaseContext(ITelegramBotClient bot, CancellationToken cancellationToken)
        {
            Bot = bot;
            CancellationToken = cancellationToken;
        }

    }

}
