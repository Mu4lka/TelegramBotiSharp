using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.ChatMember"/> handler
/// </summary>
public abstract class ChatMemberHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.ChatMember;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => new(
            builder.BotClient,
            builder.Storage,
            builder.Update,
            builder.Update.ChatMember!.From,
            null,
            builder.Token);

    public abstract Task HandleAsync(TelegramContext context);
}
