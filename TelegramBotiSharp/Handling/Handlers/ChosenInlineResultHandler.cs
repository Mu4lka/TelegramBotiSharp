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
        => new(
            builder.BotClient,
            builder.Storage,
            builder.Update,
            builder.Update.ChosenInlineResult!.From,
            builder.Update.ChosenInlineResult!.Query,
            builder.Token);

    public abstract Task HandleAsync(TelegramContext context);
}
