using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;
using Telegram.Bot.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.ChannelPost"/> handler
/// </summary>
public abstract class ChannelPostHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.ChannelPost;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => builder
            .WithUser(u => u.ChannelPost!.From!)
            .WithData(u => u.ChannelPost!.Text!)
            .WithUserStorageItem(u => u.ChannelPost!.From!.Id)
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
