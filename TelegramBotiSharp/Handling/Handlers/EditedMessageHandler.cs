using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.EditedMessage"/> handler
/// </summary>
public abstract class EditedMessageHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.EditedMessage;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => builder
            .WithUser(u => u.EditedMessage!.From!)
            .WithData(u => u.EditedMessage!.Text!)
            .WithUserStorageItem(u => u.EditedMessage!.From!.Id)
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
