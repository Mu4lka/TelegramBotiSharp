using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.ChatBoost"/> handler
/// </summary>
public abstract class ChatBoostHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.ChatBoost;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => builder
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
