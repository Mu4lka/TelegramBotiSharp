using System.Reflection;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Types.Base;
using TelegramBotExtension.Types;

namespace TelegramBotExtension.Handling;

public class Router
{
    public delegate Task Message(MessageContext context);
    public delegate Task CallbackQuery(CallbackQueryContext context);

    public event Message? OnMessage;
    public event CallbackQuery? OnCallbackQuery;

    public virtual async Task<bool> TryHandleUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        Delegate[]? delegates;
        Context? context;

        switch (update.Type)
        {
            case UpdateType.Message when OnMessage != null:
                delegates = OnMessage.GetInvocationList();
                context = new MessageContext(botClient, cancellationToken, update.Message!);
                break;
            case UpdateType.CallbackQuery when OnCallbackQuery != null:
                delegates = OnCallbackQuery.GetInvocationList();
                context = new CallbackQueryContext(botClient, cancellationToken, update.CallbackQuery!);
                break;
            default: return false;
        }
        await HandleDelegates(delegates, context);
        return true;
    }

    public static async Task HandleDelegates(Delegate[] delegates, Context context)
    {
        foreach (var del in delegates)
        {
            if (await CheckFilters(del.Method, context))
            {
                if (del.DynamicInvoke(context) is Task task)
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
