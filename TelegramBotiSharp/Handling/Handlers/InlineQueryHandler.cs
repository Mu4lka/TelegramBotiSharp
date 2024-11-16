using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.InlineQuery"/> handler
/// </summary>
public abstract class InlineQueryHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.InlineQuery;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => builder
            .WithUser(u => u.InlineQuery!.From!)
            .WithData(u => u.InlineQuery!.Query!)
            .WithUserStorageItem(u => u.InlineQuery!.From!.Id)
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
