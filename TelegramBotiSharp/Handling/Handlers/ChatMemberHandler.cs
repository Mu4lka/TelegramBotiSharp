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
        => builder
            .WithUser(u => u.ChatMember!.From!)
            .WithUserStorageItem(u => u.ChatMember!.From!.Id)
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
