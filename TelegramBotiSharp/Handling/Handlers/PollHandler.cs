using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.Poll"/> handler
/// </summary>
public abstract class PollHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.Poll;

    public TelegramContext GetContext(TelegramContextBuilder builder)
    => builder
        .WithData(u => u.Poll!.Id)
        .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
