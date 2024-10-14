using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.EditedChannelPost"/> handler
/// </summary>
public abstract class EditedChannelPostHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.EditedChannelPost;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => new(
            builder.BotClient,
            builder.Storage,
            builder.Update,
            builder.Update.EditedChannelPost!.From,
            builder.Update.EditedChannelPost!.Text,
            builder.Token);

    public abstract Task HandleAsync(TelegramContext context);
}
