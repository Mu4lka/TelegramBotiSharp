using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.BusinessMessage"/> handler
/// </summary>
public abstract class BusinessMessageHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.BusinessMessage;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => builder
            .WithUser(u => u.BusinessMessage!.From)
            .WithData(u => u.BusinessMessage!.Text)
            .WithUserStorageItem(u => u.BusinessMessage!.From!.Id)
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
