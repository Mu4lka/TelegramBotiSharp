using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Handling.Handlers;
using TelegramBotExtension.Types;
using TelegramBotExtension.Types.Base;

namespace TelegramBotExtension.Handling
{
    public class Dispatcher : IUpdateHandler
    {
        public List<Router> Routers { get; set; }

        public Dispatcher()
        {
            Routers = new List<Router>();
        }

        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await Handle(new UpdateContext(botClient, update, cancellationToken));
        }

        private async Task Handle(UpdateContext updateContext)
        {
            foreach (var router in Routers)
            {
                var data = CreateHandlersAndContext(router, updateContext);

                List<IHandler> handlers = data.Item1;
                Context context = data.Item2;

                foreach (var handler in handlers)
                {
                    if (await CheckFilters(handler, context))
                    {
                        await handler.Execute(context);
                        return;
                    }
                }
            }
        }

        private static async Task<bool> CheckFilters(IHandler handler, Context context)
        {
            var filters = handler.GetType().GetCustomAttributes(false);

            foreach (FilterAttribute filter in filters)
            {
                if (await filter.Call(context))
                    continue;
                else return false;
            }
            return true;
        }

        private (List<IHandler>, Context) CreateHandlersAndContext(Router router, UpdateContext updateContext)
        {
            var updateType = updateContext.Update.Type;

            List<IHandler> handlers = new List<IHandler>();
            Context? context = null;

            if (updateType == UpdateType.Message)
            {
                handlers = router.Handlers.OfType<MessageHandler>().Cast<IHandler>().ToList();
                context = new MessageContext(
                    updateContext.Bot,
                    updateContext.CancellationToken,
                    updateContext.Update.Message!
                    );
            }
            else if (updateType == UpdateType.CallbackQuery)
            {
                handlers = router.Handlers.OfType<CallbackQueryHandler>().Cast<IHandler>().ToList();
                context = new CallbackQueryContext(
                    updateContext.Bot,
                    updateContext.CancellationToken,
                    updateContext.Update.CallbackQuery!
                    );
            }

            if (context == null)
            {
                throw new Exception("Context is null");
            }

            return (handlers, context);
        }

    }

}
