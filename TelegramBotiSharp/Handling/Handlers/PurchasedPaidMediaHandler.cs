using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.PurchasedPaidMedia"/> handler
/// </summary>
public abstract class PurchasedPaidMediaHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.PurchasedPaidMedia;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => builder
            .WithUser(u => u.PurchasedPaidMedia!.From)
            .WithData(u => u.PurchasedPaidMedia!.PaidMediaPayload)
            .WithUserStorageItem(u => u.PurchasedPaidMedia!.From.Id)
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
