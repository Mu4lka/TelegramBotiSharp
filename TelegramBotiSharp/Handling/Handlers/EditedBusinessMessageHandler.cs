using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.EditedBusinessMessage"/> handler
/// </summary>
public abstract class EditedBusinessMessageHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.EditedBusinessMessage;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => builder
            .WithUser(u => u.EditedBusinessMessage!.From!)
            .WithData(u => u.EditedBusinessMessage!.Text)
            .WithUserStorageItem(u => u.EditedBusinessMessage!.From!.Id)
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
