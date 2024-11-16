using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.RemovedChatBoost"/> handler
/// </summary>
public abstract class RemovedChatBoostHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.RemovedChatBoost;

    public TelegramContext GetContext(TelegramContextBuilder builder)
       => builder
           .WithData(u => u.RemovedChatBoost!.BoostId)
           .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
