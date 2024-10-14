using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.Poll"/> handler
/// </summary>
public abstract class PollHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.Poll;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => new(
            builder.BotClient,
            builder.Storage,
            builder.Update,
            null,
            null,
            builder.Token);

    public abstract Task HandleAsync(TelegramContext context);
}
