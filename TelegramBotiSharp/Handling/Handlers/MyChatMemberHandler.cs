using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Storages;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.MyChatMember"/> handler
/// </summary>
public abstract class MyChatMemberHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.MyChatMember;

    public TelegramContext GetContext(ITelegramBotClient botClient, IUsersStorage<long> storage, Update update)
        => new(botClient, storage, update, update.MyChatMember!.From);

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => new(
            builder.BotClient,
            builder.Storage,
            builder.Update,
            builder.Update.MyChatMember!.From,
            null,
            builder.Token);

    public abstract Task HandleAsync(TelegramContext context);
}
