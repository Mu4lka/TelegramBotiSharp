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
    => builder
        .WithUser(u => u.ShippingQuery!.From!)
        .WithData(u => u.ShippingQuery!.Id)
        .WithUserStorageItem(u => u.ShippingQuery!.From!.Id)
        .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
