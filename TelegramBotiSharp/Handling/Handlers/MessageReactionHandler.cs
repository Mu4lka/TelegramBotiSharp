using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.MessageReaction"/> handler
/// </summary>
public abstract class MessageReactionHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.MessageReaction;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => builder
            .WithUser(u => u.MessageReaction!.User)
            .WithUserStorageItem(u => u.MessageReaction!.User!.Id)
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
