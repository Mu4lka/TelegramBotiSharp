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
       => new(
           builder.BotClient,
           builder.Storage,
           builder.Update,
           builder.Update.InlineQuery!.From,
           builder.Update.InlineQuery!.Query,
           builder.Token);

    public abstract Task HandleAsync(TelegramContext context);
}
