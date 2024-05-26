using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace TelegramBotExtension.Handling
{
    public class Dispatcher : IUpdateHandler
    {
        public List<Router> Routers { get; set; }

        public Dispatcher(List<Router> routers)
        {
            Routers = routers;
        }

        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await Handle(botClient, update, cancellationToken);
        }

        private Task Handle(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }

}
