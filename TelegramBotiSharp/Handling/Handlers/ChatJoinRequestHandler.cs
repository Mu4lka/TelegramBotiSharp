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
        => builder
            .WithUser(u => u.ChatJoinRequest!.From!)
            .WithData(u => u.ChatJoinRequest!.Bio!)
            .WithUserStorageItem(u => u.ChatJoinRequest!.From!.Id)
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
