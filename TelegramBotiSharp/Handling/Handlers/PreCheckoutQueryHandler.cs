using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.PreCheckoutQuery"/> handler
/// </summary>
public abstract class PreCheckoutQueryHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.PreCheckoutQuery;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => new(
            builder.BotClient,
            builder.Storage,
            builder.Update,
            builder.Update.PreCheckoutQuery!.From,
            null,
            builder.Token);

    public abstract Task HandleAsync(TelegramContext context);
}
