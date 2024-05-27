using System.Reflection;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Types.Base;
using TelegramBotExtension.Types;

namespace TelegramBotExtension.Handling
{
    public class Router : IUpdateHandler
    {
        public delegate void Message(MessageContext context);
        public delegate void CallbackQuery(CallbackQueryContext context);

        public event Message? OnMessage;
        public event CallbackQuery? OnCallbackQuery;

        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message)
                await Handle(
                    OnMessage!.GetInvocationList(),
                    new MessageContext(botClient, cancellationToken, update.Message!)
                    );
            else if (update.Type == UpdateType.CallbackQuery)
                await Handle(
                    OnCallbackQuery!.GetInvocationList(),
                    new CallbackQueryContext(botClient, cancellationToken, update.CallbackQuery!)
                    );

        }

        public async Task Handle(Delegate[] delegates, Context context)
        {
            foreach (var method in delegates)
            {
                if (await CheckFilters(method.Method, context))
                {
                    method.DynamicInvoke(context);
                    return;
                }
            }
        }

        private static async Task<bool> CheckFilters(MethodInfo method, Context context)
        {
            var filters = method.GetCustomAttributes(false);

            foreach (FilterAttribute filter in filters)
            {
                if (await filter.Call(context))
                    continue;
                else return false;
            }
            return true;
        }

    }

}
