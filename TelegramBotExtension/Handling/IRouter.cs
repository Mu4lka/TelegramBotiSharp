using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotExtension.Types.Contexts;

namespace TelegramBotExtension.Handling
{
    public interface IRouter
    {
        delegate Task Message(MessageContext context);

        delegate Task EditedMessage(MessageContext context);

        delegate Task ChannelPost(MessageContext context);

        delegate Task EditedChannelPost(MessageContext context);

        delegate Task InlineQuery(InlineQueryContext context);

        delegate Task ChosenInlineResult(ChosenInlineResultContext context);

        delegate Task CallbackQuery(CallbackQueryContext context);

        delegate Task ShippingQuery(ShippingQueryContext context);

        delegate Task PreCheckoutQuery(PreCheckoutQueryContext context);

        delegate Task Poll(PollContext context);

        delegate Task PollAnswer(PollAnswerContext context);

        delegate Task MyChatMember(ChatMemberUpdatedContext context);

        delegate Task ChatMember(ChatMemberUpdatedContext context);

        delegate Task ChatJoinRequest(ChatJoinRequestContext context);

        delegate Task Error(ErrorContext context);

        delegate Task Unknown(UpdateContext context);

        Task<bool> TryHandle(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
    }
}