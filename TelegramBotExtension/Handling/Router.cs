using System.Reflection;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Types.Base;
using TelegramBotExtension.Types;

namespace TelegramBotExtension.Handling
{
    public class Router
    {
        public delegate Task Message(MessageContext context);
        public delegate Task CallbackQuery(CallbackQueryContext context);

        public event Message? OnMessage;
        public event CallbackQuery? OnCallbackQuery;

        public async Task<bool> TryHandleUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message && OnMessage != null)
                await HandleDelegates(
                    OnMessage.GetInvocationList(),
                    new MessageContext(botClient, cancellationToken, update.Message!)
                    );
            else if (update.Type == UpdateType.CallbackQuery && OnCallbackQuery != null)
                await HandleDelegates(
                    OnCallbackQuery.GetInvocationList(),
                    new CallbackQueryContext(botClient, cancellationToken, update.CallbackQuery!)
                    );
            else return false;
            return true;
        }

        public static async Task HandleDelegates(Delegate[] delegates, Context context)
        {
            foreach (var method in delegates)
            {
                if (await CheckFilters(method.Method, context))
                {
                    if (method.DynamicInvoke(context) is Task task)
                        await task;
                    return;
                }
            }
        }

        private static async Task<bool> CheckFilters(MethodInfo method, Context context)
        {
            var filters = method.GetCustomAttributes(false).OfType<FilterAttribute>();

            foreach (FilterAttribute filter in filters)
            {
                if (!await filter.Call(context))
                    return false;
            }
            return true;
        }

    }

}
