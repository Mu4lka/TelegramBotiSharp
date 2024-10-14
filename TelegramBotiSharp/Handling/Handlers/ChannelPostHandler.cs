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
        => new(
            builder.BotClient,
            builder.Storage,
            builder.Update,
            builder.Update.ChannelPost!.From,
            builder.Update.ChannelPost!.Text,
            builder.Token);

    public abstract Task HandleAsync(TelegramContext context);
}
