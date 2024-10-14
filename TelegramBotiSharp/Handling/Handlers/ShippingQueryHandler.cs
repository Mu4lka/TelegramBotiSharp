using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.ShippingQuery"/> handler
/// </summary>
public abstract class ShippingQueryHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.ShippingQuery;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => new(
            builder.BotClient,
            builder.Storage,
            builder.Update,
            builder.Update.ShippingQuery!.From,
            null,
            builder.Token);

    public abstract Task HandleAsync(TelegramContext context);
}
