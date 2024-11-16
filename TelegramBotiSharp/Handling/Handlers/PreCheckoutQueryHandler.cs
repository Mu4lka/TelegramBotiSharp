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
    => builder
        .WithUser(u => u.PreCheckoutQuery!.From!)
        .WithData(u => u.PreCheckoutQuery!.Id)
        .WithUserStorageItem(u => u.PreCheckoutQuery!.From!.Id)
        .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
