using Telegram.Bot.Types;
using Telegram.Bot;

namespace TelegramBotExtension.Handling
{
    public interface IDispatcher
    {
        Task HandleRouters(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
    }

}
