using System.Reflection;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Types.Contexts.Base;
using TelegramBotExtension.Types.Contexts;

namespace TelegramBotExtension.Handling;

public class Router : IRouter
{
    public event IRouter.Message? OnMessage;
    public event IRouter.EditedMessage? OnEditedMessage;
    public event IRouter.ChannelPost? OnChannelPost;
    public event IRouter.EditedChannelPost? OnEditedChannelPost;
    public event IRouter.InlineQuery? OnInlineQuery;
    public event IRouter.ChosenInlineResult? OnChosenInlineResult;
    public event IRouter.CallbackQuery? OnCallbackQuery;
    public event IRouter.ShippingQuery? OnShippingQuery;
    public event IRouter.PreCheckoutQuery? OnPreCheckoutQuery;
    public event IRouter.Poll? OnPoll;
    public event IRouter.PollAnswer? OnPollAnswer;
    public event IRouter.MyChatMember? OnMyChatMember;
    public event IRouter.ChatMember? OnChatMember;
    public event IRouter.ChatJoinRequest? OnChatJoinRequest;
    public event IRouter.Error? OnError;
    public event IRouter.Unknown? OnUnknown;

    public async Task<bool> TryHandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        if (OnError == null)
            return false;
        return await TryHandleDelegatesAsync(
            OnError.GetInvocationList(),
            new ErrorContext(botClient, cancellationToken, exception)
            );
    }

    public virtual async Task<bool> TryHandleRouterAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        Delegate[]? delegates;
        BaseContext? context;

        switch (update.Type)
        {
            case UpdateType.Message when OnMessage != null:
                delegates = OnMessage.GetInvocationList();
                context = new MessageContext(botClient, cancellationToken, update.Message!);
                break;
            case UpdateType.EditedMessage when OnEditedMessage != null:
                delegates = OnEditedMessage.GetInvocationList();
                context = new MessageContext(botClient, cancellationToken, update.EditedMessage!);
                break;
            case UpdateType.ChannelPost when OnChannelPost != null:
                delegates = OnChannelPost.GetInvocationList();
                context = new MessageContext(botClient, cancellationToken, update.ChannelPost!);
                break;
            case UpdateType.EditedChannelPost when OnEditedChannelPost != null:
                delegates = OnEditedChannelPost.GetInvocationList();
                context = new MessageContext(botClient, cancellationToken, update.EditedChannelPost!);
                break;
            case UpdateType.InlineQuery when OnInlineQuery != null:
                delegates = OnInlineQuery.GetInvocationList();
                context = new InlineQueryContext(botClient, cancellationToken, update.InlineQuery!);
                break;
            case UpdateType.ChosenInlineResult when OnChosenInlineResult != null:
                delegates = OnChosenInlineResult.GetInvocationList();
                context = new ChosenInlineResultContext(botClient, cancellationToken, update.ChosenInlineResult!);
                break;
            case UpdateType.CallbackQuery when OnCallbackQuery != null:
                delegates = OnCallbackQuery.GetInvocationList();
                context = new CallbackQueryContext(botClient, cancellationToken, update.CallbackQuery!);
                break;
            case UpdateType.ShippingQuery when OnShippingQuery != null:
                delegates = OnShippingQuery.GetInvocationList();
                context = new ShippingQueryContext(botClient, cancellationToken, update.ShippingQuery!);
                break;
            case UpdateType.PreCheckoutQuery when OnPreCheckoutQuery != null:
                delegates = OnPreCheckoutQuery.GetInvocationList();
                context = new PreCheckoutQueryContext(botClient, cancellationToken, update.PreCheckoutQuery!);
                break;
            case UpdateType.Poll when OnPoll != null:
                delegates = OnPoll.GetInvocationList();
                context = new PollContext(botClient, cancellationToken, update.Poll!);
                break;
            case UpdateType.PollAnswer when OnPollAnswer != null:
                delegates = OnPollAnswer.GetInvocationList();
                context = new PollAnswerContext(botClient, cancellationToken, update.PollAnswer!);
                break;
            case UpdateType.MyChatMember when OnMyChatMember != null:
                delegates = OnMyChatMember.GetInvocationList();
                context = new ChatMemberUpdatedContext(botClient, cancellationToken, update.MyChatMember!);
                break;
            case UpdateType.ChatMember when OnChatMember != null:
                delegates = OnChatMember.GetInvocationList();
                context = new ChatMemberUpdatedContext(botClient, cancellationToken, update.ChatMember!);
                break;
            case UpdateType.ChatJoinRequest when OnChatJoinRequest != null:
                delegates = OnChatJoinRequest.GetInvocationList();
                context = new ChatJoinRequestContext(botClient, cancellationToken, update.ChatJoinRequest!);
                break;
            case UpdateType.Unknown when OnUnknown != null:
                delegates = OnUnknown.GetInvocationList();
                context = new UpdateContext(botClient, cancellationToken, update);
                break;
            default: return false;
        }
        return await TryHandleDelegatesAsync(delegates, context);
    }

    private static async Task<bool> TryHandleDelegatesAsync(Delegate[] delegates, BaseContext context)
    {
        foreach (var del in delegates)
        {
            if (await CheckFiltersAsync(del.Method, context))
            {
                if (del.DynamicInvoke(context) is Task task)
                    await task;
                return true;
            }
        }
        return false;
    }

    private static async Task<bool> CheckFiltersAsync(MethodInfo method, BaseContext context)
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
