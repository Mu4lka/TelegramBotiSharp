using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.ChatJoinRequest"/> handler
/// </summary>
public abstract class ChatJoinRequestHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.ChatJoinRequest;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => new(
            builder.BotClient,
            builder.Storage,
            builder.Update,
            builder.Update.ChatJoinRequest!.From,
            builder.Update.ChatJoinRequest!.Bio,
            builder.Token);

    public abstract Task HandleAsync(TelegramContext context);
}
