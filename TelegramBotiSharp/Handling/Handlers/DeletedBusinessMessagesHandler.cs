using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.DeletedBusinessMessages"/> handler
/// </summary>
public abstract class DeletedBusinessMessagesHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.DeletedBusinessMessages;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => builder
            .WithData(u => u.DeletedBusinessMessages!.BusinessConnectionId)
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
