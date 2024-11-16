using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.CallbackQuery"/> handler
/// </summary>
public abstract class CallbackQueryHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.CallbackQuery;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => builder
            .WithUser(u => u.CallbackQuery!.From!)
            .WithData(u => u.CallbackQuery!.Data!)
            .WithUserStorageItem(u => u.CallbackQuery!.From!.Id)
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
