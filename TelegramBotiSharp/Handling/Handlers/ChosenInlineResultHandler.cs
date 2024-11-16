using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.ChosenInlineResult"/> handler
/// </summary>
public abstract class ChosenInlineResultHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.ChosenInlineResult;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => builder
            .WithUser(u => u.ChosenInlineResult!.From!)
            .WithData(u => u.ChosenInlineResult!.Query)
            .WithUserStorageItem(u => u.ChosenInlineResult!.From!.Id)
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
