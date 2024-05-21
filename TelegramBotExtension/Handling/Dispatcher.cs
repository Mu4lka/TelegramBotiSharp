using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotExtension.Types;

namespace TelegramBotExtension.Handling
{
    public class Dispatcher(IEnumerable<RouterGroup> routerGroup) : IDispatcher, IUpdateHandler
    {
        public IEnumerable<RouterGroup> RouterGroup = routerGroup;

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await HandleRouters(botClient, update, cancellationToken);
        }

        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        public async Task HandleRouters(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            UpdateType updateType = update.Type;

            foreach (var routerGroup in RouterGroup)
            {
                foreach (var router in routerGroup.Routers)
                {
                    
                }
            }
        }

    }

}
