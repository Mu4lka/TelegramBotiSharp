using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotExtension.Types.Base;

namespace TelegramBotExtension.Types
{
    public class UpdateContext : BaseContext
    {
        public Update Update { get; set; }

        public UpdateContext(
            ITelegramBotClient bot,
            Update update,
            CancellationToken cancellationToken
            ) : base(bot, cancellationToken)
        {
            Update = update;
        }

    }

}
