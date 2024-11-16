using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.BusinessConnection"/> handler
/// </summary>
public abstract class BusinessConnectionHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.BusinessConnection;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => builder
            .WithUser(u => u.BusinessConnection!.User)
            .WithUserStorageItem(u => u.BusinessConnection!.User.Id)
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
