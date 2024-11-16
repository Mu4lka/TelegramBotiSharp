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

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => builder
            .WithUser(u => u.MyChatMember!.From!)
            .WithUserStorageItem(u => u.MyChatMember!.From!.Id)
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
